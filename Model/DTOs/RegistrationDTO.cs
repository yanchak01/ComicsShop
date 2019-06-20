using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.DTOs
{
    public class RegistrationDTO
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name="UserName")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }

        //[Required]
        [Display(Name = "Phone")]
        [Phone]
        [RegularExpression(@"^\+[0-9]{11,12}$", ErrorMessage = "Wrong phone number")]
        public string Phone { get; set; }

        [Display(Name ="Role")]
        public string Role { get; set; }
    }
}
