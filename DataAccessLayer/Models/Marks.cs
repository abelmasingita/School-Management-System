﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    [Table("Marks")]
    public class Marks
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Student Id")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [DisplayName("Subject Id")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        [DisplayName("Grade Value")]
        public string GradeValue { get; set; }
    }
}
