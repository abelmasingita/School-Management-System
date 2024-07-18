using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    [Table("Parent")]
    public class Parent
    {
        [Key] //FK to User
        public int Id { get; set; }

        public string UserID { get; set; }  // Foreign Key to ApplicationUser
        public User User { get; set; }

        public ICollection<Student> Children { get; set; }
    }
}
