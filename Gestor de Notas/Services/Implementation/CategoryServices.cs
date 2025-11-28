using Gestor_de_Notas.Data;
using Gestor_de_Notas.Data.Entities;
using Gestor_de_Notas.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using Tareas.Core;

namespace Gestor_de_Notas.Services.Implementation
{
    public class CategoryServices : ICategoryServices
    {
        private readonly DataContext _context;
        public CategoryServices(DataContext context)
        {
            _context = context;
        }
        public async Task<Response<List<Category>>> GetListAsync()
        {
            try
            {
                List<Category> response = await _context.Category.ToListAsync();
                return Response<List<Category>>.Succeded(response);
            }
            catch (Exception ex)
            {
                return Response<List<Category>>.Failure(ex);
            }
        }
        public async Task<Response<Category>> CreateCategoryAsync(Category categoria)
        {
            try
            {
                categoria.Id = Guid.NewGuid();
                await _context.Category.AddAsync(categoria);
                await _context.SaveChangesAsync();
                return Response<Category>.Succeded(categoria, "Categoría creada con éxito");
            }
            catch (Exception ex)
            {
                return Response<Category>.Failure(ex);
            }
        }
    }
}
