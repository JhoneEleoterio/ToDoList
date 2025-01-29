using WebAPI.Models;
using WebAPI.Models.DTOs;
using WebAPI.Services;

namespace WebAPI.Endpoints
{
    public static class TodoEndpoints
    {
        public static IEndpointRouteBuilder MapTodoEndpoints(this IEndpointRouteBuilder endpoints)
        {
            
            endpoints.MapGet("/api/todos", async (ITodoService toDoService) =>
            {
                var todos = await toDoService.GetAllAsync();
                return Results.Ok(todos);
            });

            endpoints.MapPost("/api/todos", async (ITodoService toDoService, TodoItemDto todoItemDto) =>
            {
                var toDoItem = new TodoItem(title: todoItemDto.Title);
                await toDoService.AddAsync(toDoItem);
                return Results.Created($"/api/todos/{toDoItem.Id}", toDoItem);
            });

            endpoints.MapPut("/api/todos/{id:guid}/complete", async (ITodoService toDoService, Guid id) =>
            {
                var isCompleted = await toDoService.MarkCompleteAsync(id);
                return isCompleted ? Results.NoContent() : Results.NotFound();
            });

            endpoints.MapDelete("/api/todos/{id:guid}", async (ITodoService toDoService, Guid id) =>
            {
                Guid? itemDeleted = await toDoService.DeleteAsync(id);
                return itemDeleted.HasValue ? Results.NoContent() : Results.NotFound();
            });

            return endpoints;
        }
    }
}
