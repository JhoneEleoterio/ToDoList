using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Endpoints
{
    public static class TodoEndpoints
    {
        public static IEndpointRouteBuilder MapTodoEndpoints(this IEndpointRouteBuilder endpoints)
        {
            // Endpoint para obter todos os itens
            endpoints.MapGet("/todos", async (ITodoService toDoService) =>
            {
                var todos = await toDoService.GetAllAsync();
                return Results.Ok(todos);
            });

            // Endpoint para adicionar um novo item
            endpoints.MapPost("/todos", async (ITodoService toDoService, TodoItem toDoItem) =>
            {
                await toDoService.AddAsync(toDoItem);
                return Results.Created($"/todos/{toDoItem.Id}", toDoItem);
            });

            // Endpoint para marcar um item como concluído
            endpoints.MapPut("/todos/{id:guid}/complete", async (ITodoService toDoService, Guid id) =>
            {
                var isCompleted = await toDoService.MarkCompleteAsync(id);
                return isCompleted ? Results.NoContent() : Results.NotFound();
            });

            // Endpoint para excluir um item
            endpoints.MapDelete("/todos/{id:guid}", async (ITodoService toDoService, Guid id) =>
            {
                Guid? itemDeleted = await toDoService.DeleteAsync(id);
                return itemDeleted.HasValue ? Results.NoContent() : Results.NotFound();
            });

            return endpoints;
        }
    }
}
