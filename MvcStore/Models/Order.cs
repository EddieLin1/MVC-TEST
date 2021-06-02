using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcStore.Models
{
    public class Order
    {
        [Key]
        public int OrderId {get; set;}
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 2,
        ErrorMessage = "First Name should be minimum 3 characters and a maximum of 50 characters")]
        [DataType(DataType.Text)]
        public string FirstName  { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, MinimumLength = 2,
        ErrorMessage = "First Name should be minimum 3 characters and a maximum of 50 characters")]
        [DataType(DataType.Text)]
        public string LastName   { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "Address should be minimum 3 characters and a maximum of 50 characters")]
        public string Address    { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City       { get; set; }
        [Required(ErrorMessage = "Province/State is required")]
        public string State_Province  { get; set; }
        [Required(ErrorMessage = "A Postal Code is required.")]
        [RegularExpression(@"^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]$", ErrorMessage = "Invalid Phone Number.")]
        public string PostalCode { get; set; }
        public string Country    { get; set; }
        [Display(Name = "Phone Number:")]
        [Required(ErrorMessage = "A Phone number is required.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        public string Phone      { get; set; }
        [Display(Name = "Email Address:")]
        [Required(ErrorMessage = "An Email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Email is not valid")]
        public string Email      { get; set; }
        public int CartId {get; set;}

        public double Total     { 
            get{return OrderCart.CartTotal;}
        }
        [NotMapped]
        public Cart OrderCart {get; set;}

    }
}