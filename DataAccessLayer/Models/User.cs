﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class User : IdentityUser
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Gender")]
        public String Gender { get; set; }

        [DisplayName("Address")]
        public String Address { get; set; }

        [DisplayName("Active Status")]
        public ActiveStatus Active { get; set; }

        [Display(Name = "School Id")]
        public int SchoolId { get; set; }
        public School School { get; set; }

        //mavigation properties
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public Parent Parent { get; set; }
    }

    public enum ActiveStatus { NotActive, Active }
}