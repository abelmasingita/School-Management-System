using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    [Table("Classes")]
    public class Class
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Class Name")]
        public string ClassName { get; set; }
        [DisplayName("Teacher Id")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        //navigation properties
        public ICollection<Student> Students { get; set; }

    }
}
