using story.App.CodeFirstEntity.Entities;
using System.ComponentModel.DataAnnotations;

namespace story.Models.Account
{
    public class LoginViewModel
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember")]
        public bool RememberMe { get; set; }
    }
}