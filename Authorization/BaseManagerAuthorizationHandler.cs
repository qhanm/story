using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using story.App.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace story.Authorization
{
    public class BaseManagerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, string>
    {
        private readonly IPermissionServiceInterface _permissonServiceInterface;

        public BaseManagerAuthorizationHandler(IPermissionServiceInterface permissionServiceInterface)
        {
            _permissonServiceInterface = permissionServiceInterface;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, string resource)
        {
            var roles = ((ClaimsIdentity)context.User.Identity).Claims.FirstOrDefault(x => x.Type == "Roles");

            if(roles != null)
            {
                var listRole = roles.Value.Split(";");
                var hasPermission = _permissonServiceInterface.CheckPermission(resource, requirement.Name, listRole);

                if( hasPermission || listRole.Contains("SupperAdmin"))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }


            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
