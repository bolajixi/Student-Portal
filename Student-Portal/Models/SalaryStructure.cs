using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Student_Portal.Models
{
    public class SalaryStructure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("StructId")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }


        [Required]
        [Display(Name ="Base Salary"), DataType(DataType.Currency)]
        public decimal BaseSalary { get; set; }

        [Required, Display(Name ="(%) Pay Width")]
        [Range(1, 60, ErrorMessage = "Enter a percentage between 1 and 20")]
        public float PayWidth { get; set; }

        [Required]
        [Display(Name = "Maximum Pay"), DataType(DataType.Currency)]
        public decimal MinPay { get; set; }

        [Required]
        [Display(Name ="Minimum Pay"), DataType(DataType.Currency)]
        public decimal MaxPay { get; set; }

        //----Allowance-----------------------------
        [Required, Display(Name = "(%) Allowance")]
        [Range(1, 20, ErrorMessage = "Enter a percentage between 1 and 20")]
        public int Allowance { get; set; }

        [Required, Display(Name = "(%) Housing Allowance")]
        [Range(1, 20, ErrorMessage = "Enter a percentage between 1 and 20")]
        public int Housing { get; set; }

        [Required, Display(Name = "(%) Medical Allowance")]
        [Range(1, 20, ErrorMessage = "Enter a percentage between 1 and 20")]
        public int Medicals { get; set; }

        //----Deduction-----------------------------
        [Required, Display(Name = "(%) Tax")]
        [Range(1, 20, ErrorMessage = "Enter a percentage between 1 and 20")]
        public int Tax { get; set; }

        [Required, Display(Name = "(%) Pension")]
        [Range(1, 20, ErrorMessage = "Enter a percentage between 1 and 20")]
        public int Pension { get; set; }

        //------------------------------------------
        [Required]
        [Display(Name ="Net Salary"), DataType(DataType.Currency)]
        public decimal NetSalary { get; set; }

        public ICollection<Salary> Salaries { get; set; }
    }
}