using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Portal.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        [Column("CourseId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required]
        [Display(Name ="Course Code")]
        [StringLength(6)]
        public string CourseCode { get; set; }

        [Required]
        [Display(Name = "Course Unit")]
        [Range(0,3,ErrorMessage = "Enter a unit between 0 and 3")]
        public int CourseUnit { get; set; }

        [ForeignKey("Departments")]
        [Display(Name = "Department Name")]
        public int DepartmentID { get; set; }
        public virtual Departments Departments { get; set; }
    }
}