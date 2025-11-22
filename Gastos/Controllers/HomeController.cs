using Control_de_Gastos.Services.Abstract;
using Gastos.Data;
using Gastos.Data.Entities;
using Gastos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Tareas.Core;

namespace Gastos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGastosServices _gastosservices;
        private readonly ICategoriaServices _categoriaservices;

        public HomeController(ILogger<HomeController> logger, IGastosServices gastosservices, ICategoriaServices categoriaservices)
        {
            _logger = logger;
            _gastosservices = gastosservices;
            _categoriaservices = categoriaservices;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Response<List<Perdidas>> list = await _gastosservices.GetListAsync();
            return View(list.Result);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categoria = await _categoriaservices.GetListAsync();
            ViewBag.Categoria = new SelectList(categoria.Result, "id", "name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]Perdidas perdida)
        {
            await _gastosservices.CreateAsync(perdida);
            return RedirectToAction("Index");
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
