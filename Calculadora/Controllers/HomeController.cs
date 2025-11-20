using Calculadora.Data;
using Calculadora.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calculadora.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new Inputs { monto = 0, porcentaje = 0 });
        }
        [HttpPost]
        public IActionResult Calculator([FromForm] Inputs inp)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", inp);
            }

            decimal porc = inp.porcentaje / 100;
            inp.propina = (decimal)inp.monto * porc;

            return View("Index", inp);
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
