using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ProyectoCrud.DAL.Interface;
using ProyectoCrud.DAL.Models;
using ProyectoCrud.DAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL
{
    public class AuthDA : IAuth
    {
        private readonly UserManager<AppUser> manger;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IUserService _userService;

        private readonly DbpruebaContext _dbcontext;

        public AuthDA(UserManager<AppUser> manger, SignInManager<AppUser> signInManager,
            DbpruebaContext dbcontext,IUserService userService )
        {
            this.manger = manger;
            this.signInManager = signInManager;
            _dbcontext = dbcontext;
            _userService= userService;
            
        }

        public async Task<Estado> Register(RegisterRequest request)
        {
            var estado = new Estado();
            var userExists = await manger.FindByNameAsync(request.Username);
            if (userExists != null)
            {
                estado.StatusCode = 0;
                estado.Message = "Email ya fue registrado";
                return estado;
            }
            AppUser user = new AppUser()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username,
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            var result = await manger.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                estado.StatusCode = 0;
                estado.Message = "Algo salio mal";
                return estado;
            }
            estado.StatusCode = 1;
            estado.Message = "Cuenta registrada";
            return estado;
        } 
        public async Task<Estado> login(Accseso request)
        {
            var estado = new Estado();
            var user = await manger.FindByNameAsync(request.Username);
            if (user == null)
            {
                estado.StatusCode = 0;
                estado.Message = "Email invalido";
                return estado;
            }
            if (!await manger.CheckPasswordAsync(user, request.Password))
            {
                estado.StatusCode = 0;
                estado.Message = "Password incorrecto";
                return estado;
            }
            var signInResult = await signInManager.PasswordSignInAsync(user, request.Password, false, true);
            if (signInResult.Succeeded) 
            {
                var userRoles = await manger.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, request.Username),
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                estado.StatusCode = 1;
                estado.Message = "Sesion Iniciada";

            }
            else if (signInResult.IsLockedOut)
            {
                estado.StatusCode = 0;
                estado.Message = "No se ha registrado este usuario";
            }
            else
            {
                estado.StatusCode = 0;
                estado.Message = "Hubo un error al iniciar session";
            }
            return estado;
        }
        public async Task logout()
        {
            await signInManager.SignOutAsync();
        }

        public List<AppUser> GetUsers()
        {
            var _data = this.manger.Users.ToList();
            List<AppUser> _users = new List<AppUser>();
            if (_data != null && _data.Count > 0)
            {
                _data.ForEach(Item =>
                {
                    _users.Add(new AppUser()
                    {
                        Id = Item.Id,
                        UserName = Item.UserName,
                        FirstName = Item.FirstName,
                        LastName = Item.LastName,
                        Email = Item.Email,
                    });
                });
            }
            return _users;
        }

        public void SoftDelete(AppUser user)
        {
            user.EstaBorrado = true;
            _dbcontext.Update(user);
            _dbcontext.SaveChanges();
        }
        public  async Task<IdentityResult> ResetPassword(ResetPasswordRequest model)
        {
            var userId = _userService.GetUserId();
            var usuario = manger.FindByIdAsync(userId);
            return await manger.ChangePasswordAsync(await usuario, model.CurrentPassword, model.NewPassword);
           
        }

    }

}
