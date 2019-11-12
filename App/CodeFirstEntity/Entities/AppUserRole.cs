using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.CodeFirstEntity.Entities
{
    [Table("AppUserRoles")]
    public class AppUserRole : IdentityUserRole<Guid>
    {
        public AppUserRole() { }

        public AppUserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
