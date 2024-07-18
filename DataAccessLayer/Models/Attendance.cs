using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    [Table("Attendances")]
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Student Id")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [DisplayName("Attendance Date")]
        public DateTime Date { get; set; }
        [DisplayName("Attendance Status")]
        public AttendanceType Status { get; set; }
    }
    public enum AttendanceType { Present, Absent}

}
