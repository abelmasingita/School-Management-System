using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Dto.Account
{
    public class Login
    {
        [Required]
        [EmailAddress]
        [DisplayName("Email or Username")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
