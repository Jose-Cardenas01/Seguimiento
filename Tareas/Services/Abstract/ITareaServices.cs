using Tareas.Core;
using Tareas.Data.Entities;
using Tareas.DTOs;

namespace Tareas.Services.Abstract
{
    public interface ITareaServices
    {
        public Task<Response<object>> DeleteAsync(Guid id);
        public Task<Response<object>> UpdateAsync(Guid id);
        public Task<Response<TareaDTO>> CreateAsync(TareaDTO dto);
        public Task<Response<List<TareaDTO>>> GetListAsync(bool hidden);
    }
}
