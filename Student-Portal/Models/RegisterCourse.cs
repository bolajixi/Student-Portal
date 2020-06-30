using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Portal.Models
{
    [Table("Registered Courses")]
    public class RegisterCourse
    {
        [Key]
        [Column("EnrollmentID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Course Name")]
        public int CourseId { get; set; }

        public string UserId { get; set; }

        public String EnrollmentDate { get; set; }

        public Course Course { get; set; }
    }
}