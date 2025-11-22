using Gastos.Data.Entities;
using Tareas.Core;

namespace Control_de_Gastos.Services.Abstract
{
    public interface ICategoriaServices
    {
        public Task<Response<Categoria>> CreateAsync(Categoria categoria);
        public Task<Response<Categoria>> GetOneAsync(Guid id);
        public Task<Response<List<Categoria>>> GetListAsync();
    }
}
