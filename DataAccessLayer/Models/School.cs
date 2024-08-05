using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    [Table("Schools")]
    public class School
    {
        [Key]
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

        //mavigation properties
        public ICollection<Grade> Grades { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Stream> Streams { get; set; }
        public ICollection<User> Users { get; set; }
    }
    public enum SchoolType { Public, Private }
}
