using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    [Table("Fees")]
    public class Fee
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Student Id")]
        public int StudentId { get; set; }
        public Student Student { get; set; }


        [DisplayName("Amount")]
        public float Amount { get; set; }


        [DisplayName("Fee Due Date")]
        public DateTime DueDate { get; set; }

        [DisplayName("Fee Payment Date")]
        public DateTime PaidDate { get; set; }
    }
}
