using WebAPI.Models;

namespace WebAPI.Services
{
    public interface ITodoService
    {
        IEnumerable<TodoItem> GetAll();
        TodoItem? GetById(Guid id);
        void Add(TodoItem toDoItem);
        bool Delete(Guid id);
        bool MarkComplete(Guid id);
    }
}
