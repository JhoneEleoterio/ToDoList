using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Services;

public class TodoServiceTests
{
    private readonly TodoListContext _context; // Apenas para injeção
    private readonly TodoService _service;

    public TodoServiceTests()
    {
        // Para testes locais executando a aplicacao verifique o arquivo appSettings.json

        var options = new DbContextOptionsBuilder<TodoListContext>()
            .UseMongoDB("mongodb://admin:admin123@mongodb:27017/TodoListTestDB?authSource=admin", "TodoListTestDB")
            .Options;

        _context = new TodoListContext(options);
        _service = new TodoService(_context);

        // Limpa o banco antes de cada teste para evitar interferência
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }

    [Fact]
    public async Task Add_ShouldAddNewItem()
    {
        // Arrange
        var toDoItem = new TodoItem(title: "Task 01");

        // Act
        await _service.AddAsync(toDoItem);

        // Assert
        var items = await _service.GetAllAsync();
        Assert.Contains(items, item => item.Title == "Task 01");
    }

    [Fact]
    public async Task MarkComplete_ShouldMarkItemAsComplete()
    {
        // Arrange
        var toDoItem = new TodoItem(title: "Task 02");
        await _service.AddAsync(toDoItem);

        // Act
        await _service.MarkCompleteAsync(toDoItem.Id);

        // Assert
        var item = await _service.GetByIdAsync(toDoItem.Id);
        Assert.True(item?.IsComplete);
    }

    [Fact]
    public async Task Delete_ShouldRemoveItem()
    {
        // Arrange
        var toDoItem = new TodoItem(title: "Task 03");
        await _service.AddAsync(toDoItem);

        // Act
        var result = await _service.DeleteAsync(toDoItem.Id);

        // Assert
        Assert.True(result != Guid.Empty);
        var items = await _service.GetAllAsync();
        Assert.DoesNotContain(items, item => item.Id == toDoItem.Id);
    }
}