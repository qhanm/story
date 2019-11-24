using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using story.Extensions.Constants;

namespace story.Areas.Admin.Controllers
{
    [Route("")]
    public class PageErrorController : BaseController
    {

        [Route(RouteConstant.PageNotFound)]
        [HttpGet]
        public IActionResult PageNotFound()
        {
            return View();
        }

        [Route(RouteConstant.PageForbidden)]
        public IActionResult PageForbidden()
        {
            return View();
        }
    }
}