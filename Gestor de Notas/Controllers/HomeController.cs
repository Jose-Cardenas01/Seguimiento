using Gestor_de_Notas.Data.Entities;
using Gestor_de_Notas.Models;
using Gestor_de_Notas.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Threading.Tasks;
using Tareas.Core;

namespace Gestor_de_Notas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotesServices _notesServices;
        private readonly ICategoryServices _categoryServices;

        public HomeController(ILogger<HomeController> logger, INotesServices notesServices, ICategoryServices categoryServices)
        {
            _logger = logger;
            _notesServices = notesServices;
            _categoryServices = categoryServices;
        }
        [HttpGet]
        public async Task<IActionResult> IndexNotas([FromQuery] string? filter)
        {
            ViewBag.Filter = filter;

            if (!string.IsNullOrWhiteSpace(filter))
            {
                var response = await _notesServices.PaginationAsync(filter);
                return View(response.Result);
            }
            var model = await _notesServices.GetListAsync();
            return View(model.Result);
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
        [HttpGet]
        public async Task<IActionResult> CreateNotas()
        {

            Response<List<Category>> category = await _categoryServices.GetListAsync();
            ViewBag.category = new SelectList(category.Result, "Id", "Name");
            return View(new Notes());
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotas([FromForm] Notes note)
        {
            if (note is null)
            {
                Console.WriteLine("Note es null");
                return RedirectToAction("IndexNotas");
            }
            Response<Notes> response = await _notesServices.CreateAsync(note);
            if (!response.Success)
            {
                Console.WriteLine("response is false");
                return RedirectToAction("IndexNotas");
            }
            return RedirectToAction("IndexNotas");
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var response = await _notesServices.DeleteAsync(id);
            if (!response.Success)
            {
                Console.WriteLine("response is false");
                return RedirectToAction("IndexNotas");
            }
            return RedirectToAction("IndexNotas");
        }
        [HttpGet]
        public async Task<IActionResult> Pagination([FromQuery]string filter)
        {
            ViewBag.Filter = filter;
            var response = await _notesServices.PaginationAsync(filter);
            return View(response.Result);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View(new Category());
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm] Category cat)
        {
            if (cat is null)
            {
                Console.WriteLine("Note es null");
                return RedirectToAction("IndexNotas");
            }
            Response<Category> response = await _categoryServices.CreateCategoryAsync(cat);
            if (!response.Success)
            {
                Console.WriteLine("response is false");
                return RedirectToAction("IndexNotas");
            }
            return RedirectToAction("IndexNotas");
        }
    }
}
