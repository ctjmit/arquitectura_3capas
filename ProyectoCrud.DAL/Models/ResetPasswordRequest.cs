using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Models
{
    public class ResetPasswordRequest
    {
        [Required, DataType(DataType.Password), Display(Name = "Contraseña Actual")]
        public string CurrentPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Nueva Contraseña")]
        public string NewPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Confirme Nueva Contraseña")]
        [Compare("NewPassword", ErrorMessage ="Password does not macth")]
        public string ConfirmNewPassword { get; set; }
    }
}
