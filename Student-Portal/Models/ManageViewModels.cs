using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Student_Portal.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }

    public class ProfileViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        //public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }

        //[Display(Name = "Role")]
        //public string RoleeName { get; set; }

        //[Display(Name = "Faculty Rank")]
        //public string Rank { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------

        //Personal Details
        [Required(ErrorMessage = "Oops! You missed your first name")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Oops! You missed your last name")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        //[Required(ErrorMessage = "I think you forgot pop's name")]
        [Display(Name = "Father's/Guardian's Name")]
        public string Fathername { get; set; }

        [Display(Name = "Mother's Name")]
        public string Mothername { get; set; }

        [Required(ErrorMessage = "Sneaky but you have to set a date")]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        public string DateOfBirth { get; set; }

        [Required]
        //[Display(Name = "Gender")]
        public Gender gender { get; set; }

        //---------------------------------------------------------------------------------------------------------
        //Communication Details


        //[Required(ErrorMessage = "Mobile number is required")]
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
    }
}