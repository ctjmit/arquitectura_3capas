using Microsoft.AspNetCore.Identity;
using ProyectoCrud.BL.Interface;
using ProyectoCrud.DAL.Interface;
using ProyectoCrud.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BL
{
    public class UserBL : IUserBL
    {
        private readonly IAuth _authInz;
        public UserBL(IAuth authInz)
        {
            _authInz = authInz;
        }
        public async Task<Estado> Register(RegisterRequest request)
        {
            try
            {
                return await _authInz.Register(request);
            }
            catch
            {
                throw;
            }
        }
        public async Task<Estado> login(Accseso request)
        {
            try
            {
                return await _authInz.login(request);
            }
            catch
            {
                throw;
            }
        }
        public async Task logout()
        {
            try
            {
                await _authInz.logout();
            }
            catch
            {
                throw;
            }
        }

        public List<AppUser> GetUsers()
        {
           return this._authInz.GetUsers();
        }
        public async Task<IdentityResult> ResetPassword(ResetPasswordRequest model)
        {
            return await _authInz.ResetPassword(model);
        }

        public void SoftDelete(AppUser user) => _authInz.SoftDelete(user);

    }
}
