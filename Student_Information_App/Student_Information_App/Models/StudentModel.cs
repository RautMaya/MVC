using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Information_App.Models
{
    public class StudentModel
    {
        public int Roll_No { get; set; }

        [Display(Name="Student Name")]
        public string Stud_Name { get; set; }

        [Display(Name="Student Mobile No")]
        public int Mob_No { get; set; }

        [Display(Name ="Student Address")]
        public string Address { get; set; }
    }
}