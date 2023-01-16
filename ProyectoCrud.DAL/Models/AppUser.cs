using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoCrud.DAL.Models
{
    [Keyless]
    public class AppUser : IdentityUser 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool EstaBorrado { get; set; }
 
    }
}
