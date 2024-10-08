using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Dto.Account
{
    public class Registration
    {
        [Required]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]

        [DisplayName("Gender")]
        public string Gender { get; set; }

        [Required]
        [DisplayName("Address")]
        public String Address { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        public String Phone { get; set; }

        [Required]
        public String Role { get; set; }

        [DisplayName("School Name")]
        public string School { get; set; }
    }
}
