using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAPI.Data;
using WebAPI.Services;

namespace WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        internal static IServiceCollection AddDatabaseService(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TodoListContext>(options =>
            {
                options.UseMongoDB(
                    configuration.GetConnectionString("MongoDb"),
                    "TodoList"
                );
            });

            return services;
        }

        internal static IServiceCollection AddRepositoryService(
            this IServiceCollection services)
        {
            services.AddScoped<ITodoService, TodoService>();

            return services;
        }

        internal static IServiceCollection AddSwaggerConfig(
            this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ToDoList",
                    Version = "v1",
                    Description = "Uma API para gerenciamento de tarefas"
                });
            });

            return services;
        }

    }
}
