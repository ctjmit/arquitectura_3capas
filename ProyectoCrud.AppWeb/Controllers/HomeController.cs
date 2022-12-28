using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace ProyectoCrud.AppWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}