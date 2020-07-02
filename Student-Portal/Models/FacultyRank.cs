using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Student_Portal.Models
{
    [Table("FacultyRank")]
    public class FacultyRank
    {
        [Key]
        [Column("RankId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Display(Name ="Faculty Rank")]
        public string Rank { get; set; }
    }
}