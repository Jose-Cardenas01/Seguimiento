using Gestor_de_Notas.Data.Entities;
using Tareas.Core;

namespace Gestor_de_Notas.Services.Abstract
{
    public interface INotesServices
    {
        public Task<Response<List<Notes>>> GetListAsync();
        public Task<Response<Notes>> CreateAsync(Notes note);
        public Task<Response<List<Notes>>> PaginationAsync(string filter);
        public Task<Response<Notes>> DeleteAsync(Guid id);
    }
}
