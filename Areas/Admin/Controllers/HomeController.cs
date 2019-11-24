using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using story.App.CodeFirstEntity.Entities;
using story.Areas.Admin.Page;
using story.Extensions.Constants;

namespace story.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        //private readonly UserManager<AppUser> _userManager;

        //public HomeController(UserManager<AppUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        public IActionResult Index()
        {
       
            //var user = await _userManager.GetUserAsync(User);
            //var userName = user.UserName;
            return View();
        }
    }
}