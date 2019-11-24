using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using story.Extensions.Constants;

namespace story.Areas.Admin.Controllers
{
    [Authorize]
    [Area(RouteConstant.Area)]
    public class BaseController : Controller
    {
        
    }
}