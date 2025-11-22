using Control_de_Gastos.Services.Abstract;
using Gastos.Data;
using Gastos.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Tareas.Core;

namespace Control_de_Gastos.Services.Implementation
{
    public class CategoriaServices : ICategoriaServices
    {
        private readonly DataContext _context;
        public CategoriaServices(DataContext context)
        {
            _context = context;
        }

        public async Task<Response<Categoria>> CreateAsync(Categoria categoria)
        {
            try
            {
                categoria.id = Guid.NewGuid();
                var gastos = await _context.Gastos
                    .Where(g => g.CategoriaID == categoria.id)
                    .ToListAsync();

                categoria.gastos = gastos;
                await _context.AddAsync(categoria);
                await _context.SaveChangesAsync();
                return Response<Categoria>.Succeded(categoria);
            }
            catch (Exception ex)
            {
                return Response<Categoria>.Failure(ex);
            }
        }

        public async Task<Response<List<Categoria>>> GetListAsync()
        {
            var list = await _context.categoria.ToListAsync();
            return Response<List<Categoria>>.Succeded(list);
        }

        public async Task<Response<Categoria>> GetOneAsync(Guid id)
        {
            try
            {
                Categoria? categori = await _context.categoria.FindAsync(id);
                if (categori == null)
                {
                    return new Response<Categoria>
                    {
                        Success = false,
                        Message = $"No se encontro la categoria {id}"
                    };
                }
                return Response<Categoria>.Succeded(categori);
            }
            catch (Exception ex)
            {
                return Response<Categoria>.Failure(ex);
            }
        }
    }
}
