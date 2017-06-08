using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EBuy.Models
{
    public class UsersContext : DbContext {
        public UsersContext() : base("DataContext") { 
            
        }
        public DbSet<UserProfile> UserProfiles { get; set; }

    }
    [Table("UserProfile")]
    public class UserProfile {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class LoginModel {
        [Required]
        [Display(Name="User name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string Password { get; set; }
        [Display(Name="Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterExternalLoginModel {
        [Required]
        [Display(Name="User Name")]
        public string UserName { get; set; }
        public string ExternalLoginData { get; set; }
    }

    public class RegisterModel {
        [Required]
        [Display(Name="User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        [StringLength(100,ErrorMessage="The {0} must be at least {2} characters long.",MinimumLength=6)]
        public string Password { get; set; }

        [Required]
        [Display(Name="Confirm Password")]
        [Compare("Password",ErrorMessage="The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }

    }

    public class ChangePasswordModel {
        [Required]
        [Display(Name="OldPassword")]
        [DataType(DataType.Password)]
        [StringLength(100,ErrorMessage="The {0} must be at least {2} characters long.",MinimumLength=6)]
        public string OldPassword { get; set; }
        [Required]
        [Display(Name="New Password")]
        [StringLength(100,ErrorMessage="The {0} must be at least {2} characters long.",MinimumLength=6)]
        public string NewPassword { get; set; }
        [Required]
        [Display(Name="Confirm Password")]
        [Compare("NewPassword",ErrorMessage="the new password and confirm password do not match")]
        public string ConfirmPassword { get; set; }
    }
}