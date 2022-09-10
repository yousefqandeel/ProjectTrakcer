using FinalProjectBusinessLayer.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Models
{
    public class MemberDTO
    {
        /// <summary>
        /// Validations 
        /// </summary>
       
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string FullName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //[datatype(datatype.password)]
        //[display(name = "confirm password")]
        //[compare("password", errormessage = "the password and confirmation password do not match.")]
        //public string confairmpassword { get; set; }
    }
}
