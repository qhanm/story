using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Model
{
    public class AppUserRoleViewModel
    {
        public AppUserRoleViewModel() { }

        public AppUserRoleViewModel(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }
    }
}
