using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Models
{
    public class RegisterRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required, MinLength(6, ErrorMessage = "Please enter at least 6 caracters")]
        public string Password { get; set; }

        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
