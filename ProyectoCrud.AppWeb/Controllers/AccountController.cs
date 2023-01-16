using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.DAL.Interface;
using ProyectoCrud.DAL.Models;

namespace ProyectoCrud.AppWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuth _authInz;
        public AccountController(IAuth authInz)
        {
            _authInz = authInz;
        }
        public IActionResult Index()
        {
            List<AppUser> users = this._authInz.GetUsers();
            return View(users);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Accseso request) 
        {
            if (!ModelState.IsValid)

                return View(request);  
            var result = await _authInz.login(request);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegisterRequest request)
        {
            if (!ModelState.IsValid) { return View(request); }

            var result = await this._authInz.Register(request);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }

        [Authorize]
        public async Task<IActionResult> logout()
        {
            await this._authInz.logout();
            return RedirectToAction(nameof(Login));
        }
        [HttpGet]
        public ViewResult SoftDelete(AppUser user)
        {
            return View(user);
        }

        public IActionResult resetPass()
        {
            return View();
        }
        [HttpPost("change-password")]
        public async Task<ActionResult> resetPass(ResetPasswordRequest model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authInz.ResetPassword(model);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View();
                }
                foreach (var erro in result.Errors)
                {
                    ModelState.AddModelError("", erro.Description);
                }
            }
            return View();
        }


    }
}
