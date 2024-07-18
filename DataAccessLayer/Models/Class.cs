using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }

        public string ClassName { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}
