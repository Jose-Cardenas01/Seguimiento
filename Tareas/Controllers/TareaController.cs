using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tareas.Core;
using Tareas.Data;
using Tareas.Data.Entities;
using Tareas.DTOs;
using Tareas.Services.Abstract;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Tareas.Controllers
{
    public class TareaController : Controller
    {
        private readonly ITareaServices _tareaservices;
        private readonly DataContext _context;
        public TareaController(ITareaServices services, DataContext context)
        {
            _tareaservices = services;
            _context = context;
        }
        // GET: TareaController
        public async Task<IActionResult> Index()
        {
            Response<List<TareaDTO>> response = await _tareaservices.GetListAsync(false);
            return View(response.Result);
        }

        [HttpGet]
        public async Task<IActionResult> Completadas()
        {
            var response = await _tareaservices.GetListAsync(true);
            return View(response.Result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]TareaDTO tarea)
        {
            var newtask = await _tareaservices.CreateAsync(tarea);
            if (!newtask.Success)
            {
                Console.WriteLine(newtask.Message);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Ready([FromRoute]Guid id)
        {
            await _tareaservices.UpdateAsync(id);
            return RedirectToAction("Index", "Tarea");
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _tareaservices.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
