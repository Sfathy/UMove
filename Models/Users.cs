using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class Users
    {
        public int UserID { get; set; }
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(UMoveNew.Views.user.user))]
        [Display(Name = "Name", ResourceType = typeof(UMoveNew.Views.user.user))]
        public string Name { get; set; }
        [Required(ErrorMessageResourceName = "UserNameRequired",ErrorMessageResourceType = typeof(UMoveNew.Views.user.user))]
        [Display(Name = "UserName", ResourceType = typeof(UMoveNew.Views.user.user))]
        public string UserName { get; set; }
        [Required(ErrorMessageResourceName = "PasswordRequired",ErrorMessageResourceType = typeof(UMoveNew.Views.user.user))]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password", ResourceType = typeof(UMoveNew.Views.user.user))]
        public string Password { get; set; }
         [Required(ErrorMessageResourceName ="EmailRequired",ErrorMessageResourceType = typeof(UMoveNew.Views.user.user))]
         [DataType(DataType.EmailAddress)]
         [Display(Name = "Email", ResourceType = typeof(UMoveNew.Views.user.user))]
        public string Email { get; set; }
        public string InstallationKey { get; set; }
        public int TokenID { get; set; }
        [Required(ErrorMessageResourceName = "AddressRequired", ErrorMessageResourceType = typeof(UMoveNew.Views.user.user))]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Address", ResourceType = typeof(UMoveNew.Views.user.user))]
        public string Address { get; set; }
       [Required(ErrorMessageResourceName = "PhoneRequired", ErrorMessageResourceType = typeof(UMoveNew.Views.user.user))]
       [Display(Name = "Phone", ResourceType = typeof(UMoveNew.Views.user.user))]
        public string Phone { get; set; }
        
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceName = "confirmationpassword", ErrorMessageResourceType = typeof(UMoveNew.Views.user.user))]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(UMoveNew.Views.user.user))]
        public string ConfirmPassword { get; set; }

        public int Type { get; set; }
        public int CarType { get; set; }
    }
    public class LoginModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(UMoveNew.Views.user.Login))]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password",ResourceType=typeof(UMoveNew.Views.user.Login))]
        public string Password { get; set; }



        public string InstallationKey { get; set; }
    }
}