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
        public const string RoleSaveChanges = "/admin/role/savechanges";
        public const string RoleGetAppPermissionByRoleId = "/admin/role/get-permission-by-id";

        // USERs
        public const string UserIndex = "/admin/user/index";
        public const string UserCreate = "/admin/user/create";
        public const string UserUpdate = "/admin/user/update";
        public const string UserView = "/admin/user/view";
        public const string UserDelete = "/admin/user/delete";
        public const string UserSaveChanges = "/admin/user/save-changes";
    }
}
