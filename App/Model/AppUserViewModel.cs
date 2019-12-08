using story.App.CodeFirstEntity.Constant;
using System;
using System.ComponentModel.DataAnnotations;

namespace story.App.Model
{
    public class AppUserViewModel
    {
        public AppUserViewModel() { }

        public AppUserViewModel(Guid id, string fullName, string avatar, string email, string userName, string password, string phoneNumber)
        {
            Id = id;
            FullName = fullName;
            Avatar = avatar;
            Email = email;
            UserName = userName;
            Password = password;
            PhoneNumber = phoneNumber;

        }

        public string PhoneNumber { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }

        public Guid Id { get; set; }

        [Required]
        [StringLength(150)]
        public string FullName { get; set; }

        [StringLength(200)]
        public string Avatar { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Status Status { get; set; }

        [Required(ErrorMessage = "You need choose role for user")]
        public Guid RoleId { get; set; }
    }
}