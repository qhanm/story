using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using story.App.CodeFirstEntity.Constant;
using story.App.Model;
using story.App.Services.ServiceInterface;
using story.Authorization;
using story.Extensions.Constants;
using story.Extensions.Helpers.GenerricHtml;
using story.Extensions.Helpers.Pagination;

namespace story.Areas.Admin.Controllers
{
    public class AppUserController : BaseController
    {
        private readonly IAppUserServiceInterface _appUserServiceInterface;

        private readonly IAuthorizationService _authorizationService;

        private readonly IAppRoleServiceInterface _appRoleServiceInterface;

        private readonly IAppUserRoleServiceInterface _appUserRoleServiceInterface;

        public AppUserController(IAppUserServiceInterface appUserServiceInterface, IAuthorizationService authorizationService,
            IAppRoleServiceInterface appRoleServiceInterface, IAppUserRoleServiceInterface appUserRoleServiceInterface)
        {
            _appUserServiceInterface = appUserServiceInterface;
            _authorizationService = authorizationService;
            _appRoleServiceInterface = appRoleServiceInterface;
            _appUserRoleServiceInterface = appUserRoleServiceInterface;
        }

        [HttpGet(RouteConstant.UserIndex)]
        public async Task<IActionResult> Index()
        {
            var result = await _authorizationService.AuthorizeAsync(User, FunctionConstant.User, Operations.Read);

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
            if (string.IsNullOrEmpty(pageSize))
            {
                pageSize = "10";
            }

            int intPageCurrent = PageHelper.ReturnDefaultValuePageCurrent(int.Parse(pageCurrent));

            int intPageSize = PageHelper.ReturnDefaultValuePageSize(int.Parse(pageSize));

            var appUser = _appUserServiceInterface.GetAll(status, search, intPageCurrent, intPageSize);

            string curentUrlPath = PageHelper.ReturnPageCurrentPagination(pathUrl, queryString);

            var selectListPagination = new SelectList(StatusList.GetListPaginate(), "Value", "Text", intPageSize);

            ViewBag.StatusSelectListItem = selectListStatus;
            ViewBag.PathUrl = curentUrlPath;
            ViewBag.PaginationSelectListItem = selectListPagination;
            ViewBag.Search = search;

            return View(appUser);
        }

        [HttpGet(RouteConstant.UserUpdate + "/{id}")]
        public IActionResult Update(Guid id)
        {
            return View();
        }

        [HttpGet(RouteConstant.UserView + "/{id}")]
        public IActionResult View(Guid id)
        {
            return View();
        }

        [HttpGet(RouteConstant.UserCreate)]
        public IActionResult Create()
        {
            var selectListStatus = new SelectList(StatusList.GetListCreate(), "Value", "Text");

            var selectListRole = new SelectList(_appRoleServiceInterface.GetAll(), "Id", "Name");

            AppUserViewModel appUserViewModel = new AppUserViewModel();
            ViewBag.Roles = selectListRole;
            ViewBag.StatusList = selectListStatus;

            return View("Form" ,appUserViewModel);
        }

        [HttpPost(RouteConstant.UserCreate)]
        public IActionResult SaveChanges(AppUserViewModel appUserViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var role = _appRoleServiceInterface.FindId(appUserViewModel.RoleId);

                    if (role == null)
                    {
                        throw new Exception("Role not found, please check again");
                    }

                    if(_appUserServiceInterface.IsUnique(appUserViewModel.UserName, "username") == false)
                    {
                        throw new Exception("Username must is inuque");
                    }

                    if (_appUserServiceInterface.IsUnique(appUserViewModel.Email, "email") == false)
                    {
                        throw new Exception("Email must is inuque");
                    }

                    PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

                    appUserViewModel.Password = passwordHasher.HashPassword(appUserViewModel.UserName, appUserViewModel.Password);

                    var appUserResult = _appUserServiceInterface.Add(appUserViewModel);

                    AppUserRoleViewModel appUserRole = new AppUserRoleViewModel();

                    appUserRole.UserId = appUserResult.Id;
                    appUserRole.RoleId = role.Id;

                    _appUserRoleServiceInterface.Add(appUserRole);

                    _appUserServiceInterface.SaveChanges();

                    return Redirect(RouteConstant.UserIndex);
                }

                throw new Exception("Create user not success, please check again");
                
            }
            catch(Exception exception)
            {
                var selectListStatus = new SelectList(StatusList.GetListCreate(), "Value", "Text");

                var selectListRole = new SelectList(_appRoleServiceInterface.GetAll(), "Id", "Name");

                AppUserViewModel app = new AppUserViewModel();
                ViewBag.Roles = selectListRole;
                ViewBag.StatusList = selectListStatus;


                ModelState.AddModelError("", exception.Message);
                return View("Form", app);
            }
        }
    }
}