using Gestor_de_Notas.Data.Entities;
using Tareas.Core;

namespace Gestor_de_Notas.Services.Abstract
{
    public interface ICategoryServices
    {
        public Task<Response<List<Category>>> GetListAsync();
        public Task<Response<Category>> CreateCategoryAsync(Category categoria);
    }
}
