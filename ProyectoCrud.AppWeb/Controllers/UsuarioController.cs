using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.BL.Interface;
using MU = ProyectoCrud.DAL.Models;

namespace ProyectoCrud.AppWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioBL usuarioBL;
        public UsuarioController(IUsuarioBL usuarioBL)
        {
            this.usuarioBL = usuarioBL;
        }
        public async Task<IActionResult> Index()
        {
            List<MU::Usuario> usuarios = await this.usuarioBL.GetUsuarios();
            return View(usuarios);
        }
        public IActionResult Crear()
        {
            return View(new MU.Usuario());
        }

        public async Task<IActionResult> Edit(string id)
        {
            MU::Usuario usuarios = await this.usuarioBL.GetUsuariosbyid(Convert.ToInt32(id));
            return View("Crear", usuarios);
        }
        public async Task<IActionResult> Guardar(MU::Usuario usuario)
        {
            string Response = await this.usuarioBL.Guardar(usuario);
            return Json(Response);
        }
        public async Task<IActionResult> EliminarUsuario(string id)
        {
            string Response = await this.usuarioBL.Eliminar(Convert.ToInt32(id));
            return Json(Response);
        }


    }
}
