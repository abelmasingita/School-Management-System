﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("Student")]
    public class Student
    {
        [Key] //FK to User
        public int Id { get; set; }

        public string UserID { get; set; }  // Foreign Key to ApplicationUser
        public User User { get; set; }

        [DisplayName("Admission Date")]
        public DateTime AdmissionDate { get; set; }

    }
}
