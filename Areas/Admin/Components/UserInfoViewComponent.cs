using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using story.App.CodeFirstEntity.Entities;
using story.App.Model;
using story.Extensions.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace story.Areas.Admin.Components
{
    public class UserInfoViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string position)
        {
            var email = ((ClaimsPrincipal)User).GetSpecificClaim("Email");
            var fullName = ((ClaimsPrincipal)User).GetSpecificClaim("FullName");
            //string role = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");
            var userId = ((ClaimsPrincipal)User).GetSpecificClaim("UserId");
            var avatar = ((ClaimsPrincipal)User).GetSpecificClaim("Avatar");

            AppUserViewModel appUserViewModel = new AppUserViewModel()
            {
                FullName = fullName,
                Email = email,
                Avatar = avatar,
                Id = Guid.Parse(userId)
             };

            ViewBag.Position = position;
            //return View(appUserViewModel);
            return await Task.FromResult<IViewComponentResult>(View(appUserViewModel));
        }
    }
}
