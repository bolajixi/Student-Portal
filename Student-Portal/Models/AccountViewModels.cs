using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Student_Portal.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Role")]
        public string RoleeName { get; set; }
        //-------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------

        //Personal Details
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Father's Name is required")]
        [Display(Name = "Father's/Guardian's Name")]
        public string Fathername { get; set; }

        [Display(Name = "Mother's Name")]
        public string Mothername { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        public string DateOfBirth { get; set; }

        [Required]
        //[Display(Name = "Gender")]
        public Gender gender { get; set; }

        //---------------------------------------------------------------------------------------------------------
        //Communication Details


        [Required(ErrorMessage = "Mobile number is required")]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Required]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Required]
        [Display(Name = "City/Town")]
        public string City { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        //---------------------------------------------------------------------------------------------------------
        //Academic Details

        [Required]
        [Display(Name = "Academic Institution")]
        public string Institution { get; set; }

        [Required]
        [Display(Name = "Program Name")]
        public string Program { get; set; }

        [Required]
        [Display(Name = "Year of Joining")]
        public string YearOfJoining { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Role")]
        public string RoleeName { get; set; }

        //[Display(Name = "Faculty Rank")]
        //public string Rank { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------

        //Personal Details
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Father's Name is required")]
        [Display(Name = "Father's/Guardian's Name")]
        public string Fathername { get; set; }

        [Display(Name = "Mother's Name")]
        public string Mothername { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        public string DateOfBirth { get; set; }

        [Required]
        //[Display(Name = "Gender")]
        public Gender gender { get; set; }

        //---------------------------------------------------------------------------------------------------------
        //Communication Details


        [Required(ErrorMessage = "Mobile number is required")]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Required]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Display(Name = "City/Town")]
        public string City { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        //---------------------------------------------------------------------------------------------------------
        //Academic Details

        [Required]
        [Display(Name = "Academic Institution")]
        public string Institution { get; set; }

        [Required]
        [Display(Name = "Program Name")]
        public string Program { get; set; }

        [Required]
        [Display(Name = "Year of Joining")]
        public string YearOfJoining { get; set; }
    }

    public class RegisterFacultyViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Role")]
        public string RoleeName { get; set; }

        [Display(Name = "Faculty Rank")]
        public int Rank { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------

        //Personal Details
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        public string DateOfBirth { get; set; }

        [Required]
        //[Display(Name = "Gender")]
        public Gender gender { get; set; }

        //---------------------------------------------------------------------------------------------------------
        //Communication Details


        [Required(ErrorMessage = "Mobile number is required")]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Required]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Required]
        [Display(Name = "City/Town")]
        public string City { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        //---------------------------------------------------------------------------------------------------------
        //Academic Details

        [Required]
        [Display(Name = "Academic Institution")]
        public string Institution { get; set; }

        [Required]
        [Display(Name = "Department")]
        public string Program { get; set; }

        [Required]
        [Display(Name = "Year of Joining")]
        public string YearOfJoining { get; set; }

        public virtual Salary Salary { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
