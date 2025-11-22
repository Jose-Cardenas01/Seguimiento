using Gastos.Data.Entities;
using Tareas.Core;

namespace Control_de_Gastos.Services.Abstract
{
    public interface IGastosServices
    {
        public Task<Response<Perdidas>> CreateAsync(Perdidas gastos);
        public Task<Response<List<Perdidas>>> GetListAsync();
    }
}
