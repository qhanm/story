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

            var roles = _appRoleServiceInterface.GetAll();

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
            ViewBag.StatusSelectListItem = StatusList.GetList();
            ViewBag.Functions = functions;
            ViewBag.Roles = new AppRoleViewModel();
            return View();
        }

        [HttpPost(RouteConstant.RoleSaveChanges)]
        public IActionResult SaveChanges()
        {
            var request = HttpContext.Request.Form;

            var r1 = Request.Body;

            return View();
        }
    }
}