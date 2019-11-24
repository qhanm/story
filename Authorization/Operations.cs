using Microsoft.AspNetCore.Authorization.Infrastructure;
using story.Extensions.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.Authorization
{
    public static class Operations
    {
        public static OperationAuthorizationRequirement Create =
                new OperationAuthorizationRequirement { Name = PermissionConstant.CanCreate };

        public static OperationAuthorizationRequirement Update =
                new OperationAuthorizationRequirement { Name = PermissionConstant.CanUpdate };

        public static OperationAuthorizationRequirement Delete =
                new OperationAuthorizationRequirement { Name = PermissionConstant.CanDelete };

        public static OperationAuthorizationRequirement Read =
                new OperationAuthorizationRequirement { Name = PermissionConstant.CanRead };

        public static OperationAuthorizationRequirement Approved =
                new OperationAuthorizationRequirement { Name = PermissionConstant.CanApprove };
    }
}
