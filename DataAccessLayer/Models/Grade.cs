using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    [Table("Grades")]
    public class Grade
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Grade Name")]
        public string GradeName { get; set; }

        [DisplayName("Stream Id")]
        public int StreamId { get; set; }
        public Stream Stream { get; set; }

        [DisplayName("School Id")]
        public int SchoolId { get; set; }
        public School School { get; set; }

        //navigation properties
        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
