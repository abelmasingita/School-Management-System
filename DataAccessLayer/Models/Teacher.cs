using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("Teachers")]
    public class Teacher
    {
        [Key] //FK to User
        public int Id { get; set; }


        [DisplayName("User Id")]
        [Required]
        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; } 
        public User User { get; set; }


        //navigation properties
        public ICollection<Subject> Subject { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
