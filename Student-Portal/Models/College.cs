using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Student_Portal.Models
{
    [Table("Colleges")]
    public class College
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage ="College Name required")]
        [Display(Name ="Collage Name")]
        public string CollegeName { get; set; }

        [Required(ErrorMessage = "College Code required")]
        [Display(Name = "Collage Code")]
        public string CollegeCode { get; set; }


        [Display(Name ="Number of Department")]
        public int numDept { get; set; }
    }
}