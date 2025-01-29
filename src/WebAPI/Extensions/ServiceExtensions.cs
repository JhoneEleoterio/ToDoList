using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

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

        

    }
}
