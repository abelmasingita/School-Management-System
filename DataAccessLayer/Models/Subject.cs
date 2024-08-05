using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    [Table("Subjects")]
    public class Subject
    {
        public int Id { get; set; }

        [DisplayName("Subject Name")]
        public string SubjectName { get; set; }

        [DisplayName("School Id")]
        public int SchoolId { get; set; }
        public School School { get; set; }

        //navigation properties
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Marks> Marks { get; set; }
        public ICollection<Student> Students { get; set; }
    }

}
