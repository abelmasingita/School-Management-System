using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("TeacherSubjects")]
    public class TeacherSubject
    {
        [Key]
        public int Id { get; set; }  // Primary Key

        [Required]
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }  // Foreign Key to Teacher

        [Required]
        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }  // Foreign Key to Subject

        // Navigation properties
        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
    }

}
