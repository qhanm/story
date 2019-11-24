using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using story.App.CodeFirstEntity.Entities;
using story.Extensions.Constants;
using story.Models.Account;

namespace story.Areas.Admin.Controllers
{
    [Area(RouteConstant.Area)]
    public class LoginController : Controller
    {
        // https://forums.asp.net/t/2154504.aspx?InvalidOperationException+Unable+to+resolve+service+for+type+Microsoft+AspNetCore+Identity+UserManager+1+Microsoft+AspNetCore+Identity+IdentityUser+while+attempting+to+activate+Mobile+Areas+Identity+Pages+Account+RegisterModel+
        public readonly UserManager<AppUser> _userManager;
        public readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Authen()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authen(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return Redirect("/Admin/Home/Index");
                }
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "User is locked out, please with admin");
                }
                else
                {
                    ModelState.AddModelError("", "User or password is incorrect");
                }
            }

            return View(model);
        }
    }
}