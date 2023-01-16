using Microsoft.AspNetCore.Identity;
using ProyectoCrud.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BL.Interface
{
    public interface IUserBL
    {
        Task<Estado> Register(RegisterRequest request);
        Task<Estado> login(Accseso request);
        Task logout();
        public List<AppUser> GetUsers();
        Task<IdentityResult> ResetPassword(ResetPasswordRequest model);
        public void SoftDelete(AppUser user);
     
    }
}
