using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using story.App.CodeFirstEntity.Entities;
using story.App.Services.ServiceInterface;
using story.Extensions.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace story.Areas.Admin.Components
{
    public class FunctionViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        private IAppUserServiceInterface _appUserServiceInterface;

        private IFunctionServiceInterface _functionServiceInterface;

        private IAppUserRoleServiceInterface _appUserRoleServiceInterface;

        public FunctionViewComponent(UserManager<AppUser> userManager, IAppUserServiceInterface appUserServiceInterface, 
            IFunctionServiceInterface functionServiceInterface, IAppUserRoleServiceInterface appUserRoleServiceInterface)
        {
            _userManager = userManager;
            _appUserServiceInterface = appUserServiceInterface;
            _functionServiceInterface = functionServiceInterface;
            _appUserRoleServiceInterface = appUserRoleServiceInterface;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = ((ClaimsPrincipal)User).GetSpecificClaim("UserId");

            var appUser = _appUserServiceInterface.FindByIdNoMap(Guid.Parse(userId));

            var role = _appUserRoleServiceInterface.GetByUserId(appUser.Id);

            var function = _functionServiceInterface.GetByPermission(role.RoleId);

            return await Task.FromResult<IViewComponentResult>(View(function));
        }
    }
}
