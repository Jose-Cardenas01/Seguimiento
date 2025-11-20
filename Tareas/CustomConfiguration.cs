using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Tareas.Data;
using Tareas.Services.Abstract;
using Tareas.Services.Implementation;

namespace Tareas
{
    public static class CustomConfiguration
    {
        public static WebApplicationBuilder AddCustomConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));
            });

            //AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            //Servicios
            AddServices(builder);

            return builder;
        }
        public static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ITareaServices, TareaServices>();
        } 
    }
}
