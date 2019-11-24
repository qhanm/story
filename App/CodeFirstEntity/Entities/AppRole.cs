using Microsoft.AspNetCore.Identity;
using story.App.CodeFirstEntity.Constant;
using story.App.CodeFirstEntity.InterfaceGeneric;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace story.App.CodeFirstEntity.Entities
{
    [Table("AppRoles")]
    public class AppRole : IdentityRole<Guid>, Date, SwichStatus
    {
        public AppRole() : base()
        {
        }

        public AppRole(string name, string description) : base(name)
        {
            Description = description;
        }

        public AppRole(Guid id, string name, string desciption, Status status, DateTime dateCreated, DateTime dateUpdated)
        {
            Id = id;
            Name = name;
            Description = desciption;
            Status = status;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;
        }

        [StringLength(200)]
        [Required]
        public string Description { get; set; }

        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}