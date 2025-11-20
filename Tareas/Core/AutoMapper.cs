using AutoMapper;
using Tareas.Data.Entities;
using Tareas.DTOs;

namespace Tareas.Core
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Tarea, TareaDTO>().ReverseMap();
        }
    }
}
