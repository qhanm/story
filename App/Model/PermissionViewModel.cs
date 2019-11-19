using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Model
{
    public class PermissionViewModel
    {
        public PermissionViewModel()
        {
        }

        public PermissionViewModel(int id, Guid roleId, string functionId, bool create, bool read, bool delete, bool update, bool approved)
        {
            Id = id;
            RoleId = roleId;
            FunctionId = functionId;
            Create = create;
            Delete = delete;
            Update = update;
            Read = read;
            Approved = approved;
        }

        public PermissionViewModel(Guid roleId, string functionId, bool create, bool read, bool delete, bool update, bool approved)
        {
            RoleId = roleId;
            FunctionId = functionId;
            Create = create;
            Delete = delete;
            Update = update;
            Read = read;
            Approved = approved;
        }

        public int Id { get; set; }

        public bool Create { get; set; }

        public bool Read { get; set; }

        public bool Delete { get; set; }

        public bool Update { get; set; }

        public bool Approved { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        [Required]
        public string FunctionId { get; set; }

        public virtual AppRoleViewModel Role { get; set; }

        public virtual FunctionViewModel Function { get; set; }
    }
}
