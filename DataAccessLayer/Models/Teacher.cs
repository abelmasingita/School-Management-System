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
    [Table("Teacher")]
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Student Name")]
        public string Name { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Gender")]
        public String Gender { get; set; }

        [DisplayName("Address")]
        public String Address { get; set; }

        [DisplayName("Phone Number")]
        public String PhoneNumber { get; set; }

        [DisplayName("Email")]
        public String Email { get; set; }

        [DisplayName("Phone")]
        public String Mobile { get; set; }

        [DisplayName("Hire Date")]
        public DateTime HireDate { get; set; }

        [DisplayName("Qualification")]
        public string Qualification { get; set; }
    }
}
