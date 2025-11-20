using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tareas.Core;
using Tareas.Data;
using Tareas.Data.Entities;
using Tareas.DTOs;
using Tareas.Services.Abstract;

namespace Tareas.Services.Implementation
{
    public class TareaServices : ITareaServices
    {
        private readonly DataContext _context;
        private readonly IMapper _Mapper;
        public TareaServices(DataContext context, IMapper mapper)
        {
            _context = context;
            _Mapper = mapper;
        }
        public async Task<Response<TareaDTO>> CreateAsync(TareaDTO dto)
        {
            Guid id = Guid.NewGuid();

            Tarea tarea = _Mapper.Map<Tarea>(dto);
            tarea.Id = id;
            tarea.State = false;
            tarea.DateInitial = DateTime.Now;
            await _context.Tareas.AddAsync(tarea);
            await _context.SaveChangesAsync();
            return Response<TareaDTO>.Succeded(dto, "Tarea creada con exito");
        }

        public async Task<Response<object>> DeleteAsync(Guid id)
        {
            try
            {
                Tarea? tarea = await _context.Tareas.FindAsync(id);
                if (tarea == null)
                {
                    return Response<object>.Failure(new Exception("Tarea no encontrada"));
                }
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
                return Response<object>.Succeded(1);
            }
            catch (Exception ex)
            {
                return Response<object>.Failure(ex);
            }
        }
        public async Task<Response<List<TareaDTO>>> GetListAsync(bool hidden)
        {
            try
            {
                IQueryable<Tarea> query = _context.Tareas.AsQueryable();
                if (!hidden) //state false significa pendiente
                {
                    query = query.Where(s => !s.State);
                }
                else // state true significa completado
                {
                    query = query.Where(s => s.State);
                }

                List<Tarea> list = await query.ToListAsync();
                List<TareaDTO> listDTO = _Mapper.Map<List<TareaDTO>>(list);
                return Response<List<TareaDTO>>.Succeded(listDTO);
            }
            catch (Exception ex)
            {
                return Response<List<TareaDTO>>.Failure(ex);
            }
        }

        public async Task<Response<object>> UpdateAsync(Guid id)
        {
            Tarea? tarea = await _context.Tareas.FirstOrDefaultAsync(s => s.Id == id);
            if (tarea is null)
            {
                string mesage = "No se encontro la tarea";
                return new Response<object>
                {
                    Success = false,
                    Errors = new List<string>()
                    {
                        mesage
                    }
                };
            }
            else
            {
                tarea.State = true;
                await _context.SaveChangesAsync();
                return Response<object>.Succeded();
            }
        }
    }
}
