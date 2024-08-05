using DataAccessLayer.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreMvcFull.Models;

public class AuthViewModel
{
  public class LoginViewModel
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
  }

  public class RegisterViewModel
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

  public class TeacherViewModel
  {
    [DisplayName("Subject")]
    public string Subject { get; set; }

  }

  public class ParentViewModel
  {

  }

  public class StudentViewModel
  {
    [DisplayName("Admission Date")]
    public DateTime AdmissionDate { get; set; }

    [DisplayName("Parent")]
    public string Parent { get; set; }

    [DisplayName("Class ")]
    public string Class { get; set; }

  }


  public class CompositeViewModel 
  {
    public RegisterViewModel RegisterVM { get; set; }
    public TeacherViewModel TeacherVM { get; set; }
    public ParentViewModel ParentVM { get; set; }
    public StudentViewModel StudentVM { get; set; }
  }
}
