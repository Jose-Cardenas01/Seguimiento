using Control_de_Gastos.Services.Abstract;
using Gastos.Data;
using Gastos.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tareas.Core;

namespace Control_de_Gastos.Services.Implementation
{
    public class GastosServices : IGastosServices
    {
        private readonly DataContext _context;
        private readonly ICategoriaServices _categoriaservices;
        public GastosServices(DataContext context, ICategoriaServices categoriaservices)
        {
            _context = context;
            _categoriaservices = categoriaservices;
        }
        public async Task<Response<Perdidas>> CreateAsync(Perdidas gastos)
        {
            gastos.id = Guid.NewGuid();
            Response<Categoria> cate = await _categoriaservices.GetOneAsync(gastos.CategoriaID);
            gastos.category = cate.Result;
            await _context.AddAsync(gastos);
            await _context.SaveChangesAsync();
            return Response<Perdidas>.Succeded(gastos);
        }

        public async Task<Response<List<Perdidas>>> GetListAsync()
        {
            try
            {
                List<Perdidas> perdidas = await _context.Gastos.Include(g => g.category).ToListAsync();
               
                return Response<List<Perdidas>>.Succeded(perdidas);
            }
            catch (Exception ex)
            {
                return Response<List<Perdidas>>.Failure(ex);
            }
        }
    }
}
