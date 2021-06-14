using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MvcStore.Models.UserModels
{
    public class LoginUser : IdentityUser 
    {
        [Required]
        public string Username {get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}
        [Display(Name = "Remember me")]
        public bool RememberMe {get; set;} 
    }
}