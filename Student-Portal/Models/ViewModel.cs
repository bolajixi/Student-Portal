using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Student_Portal.Models
{
    public class ViewModel
    {
        //public Course Course { get; set; }
        //public RegisterCourse RegisterCourse { get; set; }

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Display(Name = "Course Code")]
        public String CourseCode { get; set; }

        [Display(Name = "Course Unit")]
        public int CourseUnit { get; set; }

        public int CourseId { get; set; }


    }
}