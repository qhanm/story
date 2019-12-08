using Microsoft.AspNetCore.Identity;
using story.App.CodeFirstEntity.Constant;
using story.App.CodeFirstEntity.InterfaceGeneric;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.CodeFirstEntity.Entities
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>, Date, SwichStatus
    {
        public AppUser() { }

        public AppUser(Guid id, string fullName, string avatar, string email, string userName, string password, string phoneNumber)
        {
            Id = id;
            FullName = fullName;
            Avatar = avatar;
            Email = email;
            UserName = userName;
            PasswordHash = password;
            PhoneNumber = phoneNumber;
        }

        [Required]
        [StringLength(150)]
        public string FullName { get; set; }

        [StringLength(200)]
        public string Avatar { get; set; }

        public DateTime DateCreated {get; set;}
        public DateTime DateUpdated {get; set;}
        public Status Status {get; set;}
    }
}
