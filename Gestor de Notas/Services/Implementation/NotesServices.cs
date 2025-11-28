using Gestor_de_Notas.Data;
using Gestor_de_Notas.Data.Entities;
using Gestor_de_Notas.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using Tareas.Core;

namespace Gestor_de_Notas.Services.Implementation
{
    public class NotesServices : INotesServices
    {
        private readonly DataContext _context;
        public NotesServices(DataContext context)
        {
            _context = context;
        }
        public async Task<Response<List<Notes>>> GetListAsync()
        {
            try
            {
                List<Notes> response = await _context.Notes.Include(c => c.Category).ToListAsync();
                return Response<List<Notes>>.Succeded(response);
            }
            catch (Exception ex)
            {
                return Response<List<Notes>>.Failure(ex);
            }
        }
        public async Task<Response<Notes>> CreateAsync(Notes note)
        {
            try
            {
                if (note is null)
                {
                    return new Response<Notes>
                    {
                        Success = false
                    };
                }
                await _context.Notes.AddAsync(note);
                await _context.SaveChangesAsync();
                return Response<Notes>.Succeded(note);
            }
            catch (Exception ex)
            {
                return Response<Notes>.Failure(ex);
            }
        }

        public async Task<Response<Notes>> DeleteAsync(Guid id)
        {
            Notes? response = await _context.Notes.FindAsync(id);
            if (response is null)
            {
                return new Response<Notes>
                {
                    Success = false
                };
            }
            _context.Notes.Remove(response);
            await _context.SaveChangesAsync();
            return Response<Notes>.Succeded(response, "La nota se elimino con exito");
        }
        public async Task<Response<List<Notes>>> PaginationAsync(string filter)
        {
            IQueryable<Notes>? query = _context.Notes.AsQueryable();

            if (query is null)
            {
                return new Response<List<Notes>>
                {
                    Success = false,
                };
            }

            List<Notes> response = await query.Include(c => c.Category).Where(t => t.Topic.ToLower().Contains(filter) || t.Category.Name.ToLower().Contains(filter)).ToListAsync();
            
            if (response is null)
            {
                return new Response<List<Notes>> { Success = false, };
            }

            return Response<List<Notes>>.Succeded(response);
        }
    }
}
