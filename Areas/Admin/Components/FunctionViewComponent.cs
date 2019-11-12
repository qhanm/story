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

        private readonly AppUserServiceInterface _appUserServiceInterface;

        public FunctionViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = ((ClaimsPrincipal)User).GetSpecificClaim("UserId");

            var appUser = _appUserServiceInterface.FindByIdNoMap(Guid.Parse(userId));

            var roles = _userManager.GetRolesAsync(appUser);


            return await Task.FromResult<IViewComponentResult>(View(roles));
        }
    }
}
