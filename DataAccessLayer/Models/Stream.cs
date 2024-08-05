using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    [Table("Streams")]
    public class Stream
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Stream Name")]
        public string StreamName { get; set; }

        [DisplayName("School Id")]
        public int SchoolId { get; set; }
        public School School { get; set; }

        // Navigation property
        public ICollection<Grade> Grades { get; set; }
    }
}
