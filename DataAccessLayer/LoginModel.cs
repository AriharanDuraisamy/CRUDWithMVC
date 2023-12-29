using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using DapperDataAccessLayer;

namespace DapperDataAccessLayer
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Please Enter username")]
        [EmailAddress(ErrorMessage ="please enter proper format")]
        public string EmailID { get; set; }
        [Required(ErrorMessage = "Please Enter password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$",
            ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        public string Password { get; set; }
    }
}
