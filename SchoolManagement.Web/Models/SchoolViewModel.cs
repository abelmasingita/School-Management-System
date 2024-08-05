using DataAccessLayer.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreMvcFull.Models;

public class SchoolViewModel
{
  public class SchoolVM
  {
    public int Id { get; set; }

    [DisplayName("School Name")]
    public string SchoolName { get; set; }

    [Display(Name = "Address")]
    public string Address { get; set; }

    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    [Display(Name = "Email Address")]
    public string Email { get; set; }

    [Display(Name = "Principal Name")]
    public string PrincipalName { get; set; }

    [Display(Name = "Established Year")]
    public int EstablishedYear { get; set; }

    [Display(Name = "School Type")]
    public SchoolType SchoolType { get; set; }

    [Display(Name = "Website")]
    public string Website { get; set; }
  }

  public class StreamVM
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Stream Name")]
    public string StreamName { get; set; }

    [DisplayName("School Id")]
    public int SchoolId { get; set; }
    public School School { get; set; }
  }

  public class GradeVM
  {
    [Key]
    public int Id { get; set; }

    [DisplayName("Grade Name")]
    public string GradeName { get; set; }

    [DisplayName("Stream Id")]
    public int StreamId { get; set; }
    public DataAccessLayer.Models.Stream Stream { get; set; }

    [DisplayName("School Id")]
    public int SchoolId { get; set; }
    public School School { get; set; }
  }
  public class SubjectVM
  {
    public int Id { get; set; }

    [DisplayName("Subject Name")]
    public string SubjectName { get; set; }

    [DisplayName("School Id")]
    public int SchoolId { get; set; }
    public School School { get; set; }
  }
}
