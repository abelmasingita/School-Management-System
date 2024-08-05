using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("TeacherGrades")]
    public class TeacherGrade
    {
        [Key]
        public int Id { get; set; }  

        [Required]
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; } 

        [Required]
        [ForeignKey(nameof(Grade))]
        public int GradeId { get; set; }  

        // Navigation properties
        public Teacher Teacher { get; set; }
        public Grade Grade { get; set; }
    }

}
