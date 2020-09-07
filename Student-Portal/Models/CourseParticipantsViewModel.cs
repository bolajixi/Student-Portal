using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Portal.Models
{
    public class UnapprovedStudents
    {
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }

        [Display(Name = "Enrollment Date")]
        public string EnrollmentDate { get; set; }
    }

    public class ApprovedStudents
    {
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Display(Name = "Enrollment Date")]
        public string EnrollmentDate { get; set; }

        [Display(Name = "Approval Date")]
        public string ApprovalDate { get; set; }

        [Display(Name = "Approved By")]
        public string ApprovedBy { get; set; }
    }

    public class ApprovalViewModel
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public bool Approved { get; set; }
    }
}