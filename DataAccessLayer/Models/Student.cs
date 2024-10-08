﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    [Table("Students")]
    public class Student
    {
        [Key] //FK to User
        public int Id { get; set; }

        [Required]
        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }  
        public User User { get; set; }

        [DisplayName("Parent Id")]
        public int ParentId { get; set; }
        public Parent Parent { get; set; }

        [DisplayName("Admission Date")]
        public DateTime AdmissionDate { get; set; }

        [DisplayName("Grade")]
        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        //navigation properties
        public ICollection<Marks> Marks { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Fee> Fees { get; set; }
    }
}
