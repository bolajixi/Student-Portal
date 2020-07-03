using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Portal.Models
{
    [Table("FacultyAndRanks")]
    public class FacultyAndRank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int RankId { get; set; }

        //[Required]
        public virtual string Username { get; set; }

        [ForeignKey("RankId")]
        public virtual FacultyRank FacultyRank { get; set; }
    }
}