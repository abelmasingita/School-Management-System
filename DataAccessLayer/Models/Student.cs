using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    [Table("Student")]
    public class Student
    {
        [Key] //FK to User
        public int Id { get; set; }

        public string UserID { get; set; }  // Foreign Key to ApplicationUser
        public User User { get; set; }

        [DisplayName("Admission Date")]
        public DateTime AdmissionDate { get; set; }

        public string ClassID { get; set; }
        public Class Class { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Fee> Fees { get; set; }
    }
}
