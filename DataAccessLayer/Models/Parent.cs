using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    [Table("Parents")]
    public class Parent
    {
        [Key] //FK to User
        public int Id { get; set; }


        [Required]
        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }  // Foreign Key to ApplicationUser
        public User User { get; set; }


        //navigation properties
        public ICollection<Student> Children { get; set; }
    }
}
