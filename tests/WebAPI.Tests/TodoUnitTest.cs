using WebAPI.Models;
using WebAPI.Services;

public class TodoUnitTest
{
    [Fact]
    public void Add_ShouldAddNewItem()
    {
        // Arrange
        var service = new TodoService();
        var toDoItem = new TodoItem(title: "Task 01");

        // Act
        service.Add(toDoItem);

        // Assert
        var items = service.GetAll();
        Assert.Contains(items, item => item.Title == "Task 01");
    }

    [Fact]
    public void MarkComplete_ShouldMarkItemAsComplete()
    {
        // Arrange
        var service = new TodoService();
        var toDoItem = new TodoItem(title: "Task 02");
        service.Add(toDoItem);

        // Act
        service.MarkComplete(toDoItem.Id);

        // Assert
        var item = service.GetById(toDoItem.Id);
        Assert.True(item?.IsComplete);
    }

    [Fact]
    public void Delete_ShouldRemoveItem()
    {
        // Arrange
        var service = new TodoService();
        var toDoItem = new TodoItem(title: "Task 02");
        service.Add(toDoItem);

        // Act
        var result = service.Delete(toDoItem.Id);

        // Assert
        Assert.True(result);
        Assert.DoesNotContain(service.GetAll(), item => item.Id == toDoItem.Id);
    }
}