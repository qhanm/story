using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using story.App.Services.ServiceInterface;

namespace story.Areas.Admin.Controllers
{
    public class AppRoleController : BaseController
    {
        private readonly IAppRoleServiceInterface _appRoleServiceInterface;

        public AppRoleController(IAppRoleServiceInterface appRoleServiceInterface)
        {
            _appRoleServiceInterface = appRoleServiceInterface;
        }

        public IActionResult Index()
        {
            var roles = _appRoleServiceInterface.GetAll();

            return View(roles);
        }
    }
}