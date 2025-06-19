using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Information_App.Models
{
    public class LocationModel
    {
        public int LocNo { get; set; }

        [Display(Name="Location Name")]
        public string LocName { get; set; }

        [Display(Name = " Address")]
        public string Address { get; set; }

        public int RollNo { get; set; }

        [Display(Name = "Student")]
        public string Stud_Name { get; set; }
    }
}