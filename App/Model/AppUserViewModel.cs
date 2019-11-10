using story.App.CodeFirstEntity.Constant;
using System;
using System.ComponentModel.DataAnnotations;

namespace story.App.Model
{
    public class AppUserViewModel
    {
        public AppUserViewModel() { }

        public AppUserViewModel(Guid id, string fullName, string avatar, string email)
        {
            Id = id;
            FullName = fullName;
            Avatar = avatar;
            Email = email;
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(150)]
        public string FullName { get; set; }

        [StringLength(200)]
        public string Avatar { get; set; }

        public string Email { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Status Status { get; set; }
    }
}