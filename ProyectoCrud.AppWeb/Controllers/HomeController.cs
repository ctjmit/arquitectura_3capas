using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.AppWeb.Models;
using ProyectoCrud.AppWeb.Models.viewmodels;
using ProyectoCrud.BL.Services;
using ProyectoCrud.DAL.Models;
using System.Diagnostics;
using System.Globalization;

namespace ProyectoCrud.AppWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        private readonly IUsuarioService _serviceUser;

        public HomeController(IUsuarioService serviceUser)
        {
            _serviceUser = serviceUser;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Lista()   //
        {
            IQueryable<Usuario> queryUsuarioSQL = await _serviceUser.ObtenerTodos();
            List<VMUsuario> lista = queryUsuarioSQL
                .Select(c => new VMUsuario(){
                    IdUser = c.IdUser,
                    Nombre = c.Nombre,
                    Salario= c.Salario,
                    Fecha = c.Fecha.Value.ToString("dd/MM/yyyy"),
                    Edad = c.Edad
                }).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);

        }

        [HttpPost]

        public async Task<IActionResult> Insertar([FromBody]VMUsuario modelo)   //
        {
            Usuario nuevoUsuario = new Usuario()
            {
                Nombre = modelo.Nombre,
                Salario = modelo.Salario,
                Fecha = DateTime.ParseExact(modelo.Fecha, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-SV")),
                Edad = modelo.Edad
            };
            bool respuesta = await _serviceUser.Insertar(nuevoUsuario);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody]VMUsuario modelo)   //
        {
            Usuario nuevoUsuario = new Usuario()
            {
                IdUser = modelo.IdUser,
                Nombre = modelo.Nombre,
                Salario = modelo.Salario,
                Fecha = DateTime.ParseExact(modelo.Fecha, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-SV")),
                Edad = modelo.Edad
            };
            bool respuesta = await _serviceUser.Actualizar(nuevoUsuario);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)   //
        {
            
            bool respuesta = await _serviceUser.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}