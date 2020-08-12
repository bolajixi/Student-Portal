using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Student_Portal.Models
{
    [Table("Departments")]
    public class Departments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptID { get; set; }

        [Required(ErrorMessage ="Department's Name required")]
        [Display(Name ="Department Name")]
        public string DeptName { get; set; }

        [ForeignKey("College")]
        [Display(Name = "College Name")]
        public int CollegeId { get; set; }

        public virtual College College { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}