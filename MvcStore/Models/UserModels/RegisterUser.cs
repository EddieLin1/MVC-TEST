using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MvcStore.Models.UserModels
{
    public class RegisterUser : IdentityUser
    {
        //public int Id {get; set;}
        [Required]
        [StringLength(10, ErrorMessage = "Must be between 5 and 10 characters", MinimumLength = 5)]
        public string Username {get; set;}
        [Required]
        [RegularExpression(@"^.*(([A-Z].*[a-z].*[0-9])|([A-Z].*[0-9].*[a-z])|([a-z].*[A-Z].*[0-9])|([a-z].*[0-9].*[A-Z])|([0-9].*[a-z].*[A-Z])|([0-9].*[A-Z].*[a-z])).*$", ErrorMessage = "Password should have atleast one lowercase, should have atleast one uppercase, should have atleast one digit")]
        [StringLength(255, ErrorMessage = "Must be between 6 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password {get; set;}
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm {get; set;} 
        public int OrderId {get; set;} = 0;
    }
}