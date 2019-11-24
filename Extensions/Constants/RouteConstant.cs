using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.Extensions.Constants
{
    public static class RouteConstant
    {
        public const string Area = "Admin";

        public const string PageNotFound = "/admin/404.html";

        public const string PageForbidden = "/admin/403.html";


        // ROLE
        public const string RoleIndex = "/admin/role/index";
        public const string RoleCreate = "/admin/role/create";
        public const string RoleView = "/admin/role/view";
        public const string RoleUpdate = "/admin/role/update";
        public const string RoleDelete = "/admin/role/delete";

    }
}
