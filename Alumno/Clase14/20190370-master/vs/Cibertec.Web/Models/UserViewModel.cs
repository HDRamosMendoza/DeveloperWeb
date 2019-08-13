using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cibertec.Web.Models
{
    public class UserViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Ingresa un correo válido")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}