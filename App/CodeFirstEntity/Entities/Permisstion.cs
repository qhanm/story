using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace story.App.CodeFirstEntity.Entities
{
    [Table("Permisstions")]
    public class Permisstion : PrivateKey<int>
    {
        public Permisstion()
        {
        }

        public Permisstion(int id, Guid roleId, string functionId, bool create, bool read, bool delete, bool update, bool approved)
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

        public Permisstion(Guid roleId, string functionId, bool create, bool read, bool delete, bool update, bool approved)
        {
            RoleId = roleId;
            FunctionId = functionId;
            Create = create;
            Delete = delete;
            Update = update;
            Read = read;
            Approved = approved;
        }

        [DefaultValue(false)]
        public bool Create { get; set; }

        [DefaultValue(false)]
        public bool Read { get; set; }

        [DefaultValue(false)]
        public bool Delete { get; set; }

        [DefaultValue(false)]
        public bool Update { get; set; }

        [DefaultValue(false)]
        public bool Approved { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        [Required]
        public string FunctionId { get; set; }

        [ForeignKey("RoleId")]
        public virtual AppRole Role { get; set; }

        [ForeignKey("FunctionId")]
        public virtual Function Function { get; set; }
    }
}