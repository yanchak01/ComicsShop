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
       // [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name="Name")]
        public string Name { get; set; }
    }
}
