using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using story.App.Services.ServiceInterface;
using story.Authorization;
using story.Extensions.Constants;
using System.Dynamic;
using story.Extensions.Helpers.GenerricHtml;
using story.App.Model;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using story.App.CodeFirstEntity.Entities;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using story.Extensions.Helpers.Pagination;
using story.App.CodeFirstEntity.Constant;

namespace story.Areas.Admin.Controllers
{
    
    public class AppRoleController : BaseController
    {
        private readonly IAppRoleServiceInterface _appRoleServiceInterface;

        private readonly IPermissionServiceInterface _permissionServiceInterface;

        private readonly IAuthorizationService _authorizationService;

        private readonly IFunctionServiceInterface _functionService;

        public AppRoleController(IAppRoleServiceInterface appRoleServiceInterface, IAuthorizationService authorizationService,
            IPermissionServiceInterface permissionServiceInterface, IFunctionServiceInterface functionService)
        {
            _appRoleServiceInterface = appRoleServiceInterface;
            _authorizationService = authorizationService;
            _permissionServiceInterface = permissionServiceInterface;
            _functionService = functionService;
        }

        [Route(RouteConstant.RoleIndex)]
        public async Task<IActionResult> Index()
        {
            var result = await _authorizationService.AuthorizeAsync(User, FunctionConstant.Role, Operations.Read);

            if (!result.Succeeded)
            {
                return Redirect(RouteConstant.PageForbidden);
            }
            string strStatus = HttpContext.Request.Query["status"];

            string pageCurrent = HttpContext.Request.Query["page"];

            string pageSize = HttpContext.Request.Query["pageSize"];

            string search = HttpContext.Request.Query["search"];

            string pathUrl = HttpContext.Request.Path;

            string queryString = HttpContext.Request.QueryString.ToString();
 
            if (string.IsNullOrEmpty(strStatus))
            {
                strStatus = StatusConstant.All;
            }

            var selectListStatus = new SelectList(StatusList.GetListStatusObject(), "Value", "Text", strStatus);

            Status status = StatusConstant.GetStatus(strStatus);

            if (string.IsNullOrEmpty(pageCurrent))
            {
                pageCurrent = "0";
            }
            if(string.IsNullOrEmpty(pageSize))
            {
                pageSize = "10";
            }

            int intPageCurrent = PageHelper.ReturnDefaultValuePageCurrent(int.Parse(pageCurrent));

            int intPageSize = PageHelper.ReturnDefaultValuePageSize(int.Parse(pageSize));

            var roles = _appRoleServiceInterface.GetAll(status, search, intPageCurrent, intPageSize);

            string curentUrlPath = PageHelper.ReturnPageCurrentPagination(pathUrl, queryString);

            var selectListPagination = new SelectList(StatusList.GetListPaginate(), "Value", "Text", intPageSize);

            ViewBag.StatusSelectListItem = selectListStatus;
            ViewBag.PathUrl = curentUrlPath;
            ViewBag.PaginationSelectListItem = selectListPagination;
            ViewBag.Search = search;
            return View(roles);
        }

        [HttpGet(RouteConstant.RoleView + "/{id}")]
        public IActionResult Show(Guid id)
        {
            var role = _appRoleServiceInterface.FindId(id);

            if(role == null)
            {
                return Redirect(RouteConstant.PageNotFound);
            }

            var permission = _permissionServiceInterface.GetAll(id);

            ViewBag.Permission = permission;

            return View(role);
        }

        [HttpGet(RouteConstant.RoleCreate)]
        public IActionResult Create()
        {
            var functions = _functionService.FindAll();

            List<PermissionViewModel> permissionViewModels = new List<PermissionViewModel>();

            ViewBag.StatusSelectListItem = StatusList.GetList();

            ViewBag.Functions = functions;

            ViewBag.Roles = new AppRoleViewModel();
            
            ViewBag.Permissions = permissionViewModels;

            return View();
        }

        [HttpGet(RouteConstant.RoleUpdate + "/{id}")]
        public IActionResult Update(Guid id)
        {
            var functions = _functionService.FindAll();
            ViewBag.StatusSelectListItem = StatusList.GetList();
            ViewBag.Functions = functions;

            var role = _appRoleServiceInterface.FindId(id);

            if (role == null)
            {
                return Redirect(RouteConstant.PageNotFound);
            }

            List<PermissionViewModel> permissionViewModels = _permissionServiceInterface.GetAll(id);

            ViewBag.Permissions = permissionViewModels;

            ViewBag.Roles = role;

            return View("Create");
        }

        [HttpGet(RouteConstant.RoleGetAppPermissionByRoleId + "/{id}")]

        public IActionResult GetPermissionById(Guid id)
        {
            var permissions = _permissionServiceInterface.GetAll(id);

            return Json(new { Datas = permissions });
        }

        [HttpPost(RouteConstant.RoleDelete + "/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var role = _appRoleServiceInterface.FindId(id);

                if(role == null)
                {
                    throw new Exception($"Not found role with id: {id}");
                }

                _appRoleServiceInterface.Delete(role);
                _permissionServiceInterface.DeleteByRoleId(id);
                _appRoleServiceInterface.SaveChange();
                //_permissionServiceInterface.SaveChanges();

                return Json(new { Status = true });
            }
            catch(Exception exception)
            {
                return Json(new { Status = true, Message = exception.Message });
            }
            
        }

        [HttpPost(RouteConstant.RoleSaveChanges)]
        public ActionResult SaveChanges()
        {
            try
            {
                var request = HttpContext.Request.Form.ToList();

                JObject jObjectResult = JObject.Parse(request[1].Value);

                var approleViewModel = jObjectResult.ToObject<AppRoleViewModel>();

                var appRole = new AppRole();

                var guidDefault = default(Guid);

                bool isUnique = _appRoleServiceInterface.IsUnique(approleViewModel.Name, approleViewModel.Id);

                if (!isUnique)
                {
                    throw new Exception("Name must is unique");
                }

                if (string.IsNullOrEmpty(approleViewModel.Name))
                {
                    throw new Exception("Name is can not be blank");
                }

                if (approleViewModel.Id == guidDefault)
                {
                    appRole = _appRoleServiceInterface.Add(approleViewModel);
                }
                else
                {
                    // update
                    appRole = _appRoleServiceInterface.Update(approleViewModel);
                }

                var perMissionJson = JObject.Parse(request[0].Value);

                foreach (var perJson in perMissionJson)
                {
                    var permission = perJson.Value.ToObject<PermissionViewModel>();
                    permission.RoleId = appRole.Id;

                    if(approleViewModel.Id == guidDefault)
                    {
                        // create
                        _permissionServiceInterface.Add(permission);
                    }
                    else 
                    {
                        // update
                        _permissionServiceInterface.Update(permission);
                    }
                }
                //_functionService.SaveChanges();
                _permissionServiceInterface.SaveChanges();
                //var r = JsonConvert.DeserializeObject<List<PermissionViewModel>>(request[0].Value);

                return Json(new { Status = 1, Message = "OKE" });
            }
            catch(Exception exception)
            {
       
                return Json(new { Status = 0, Message = exception.Message });

            }

        }
    }
}