using WebAPI.Models;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
#region AddServices
builder.Services.AddScoped<ITodoService, TodoService>();
#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGet("/todos", (ITodoService toDoService) => Results.Ok(toDoService.GetAll()));

app.MapPost("/todos", (ITodoService toDoService, TodoItem toDoItem) =>
{
    toDoService.Add(toDoItem);
    return Results.Created($"/todos/{toDoItem.Id}", toDoItem);
});

app.MapPut("/todos/{id:guid}/complete", (ITodoService toDoService, Guid id) =>
{
    if (toDoService.MarkComplete(id))
        return Results.NoContent();
    return Results.NotFound();
});

app.MapDelete("/todos/{id:guid}", (ITodoService toDoService, Guid id) =>
{
    if (toDoService.Delete(id))
        return Results.NoContent();
    return Results.NotFound();
});

app.Run();

