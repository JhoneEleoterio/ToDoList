using WebAPI.Models;

namespace WebAPI.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem?> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(TodoItem toDoItem);
        Task<Guid> DeleteAsync(Guid id);
        Task<bool> MarkCompleteAsync(Guid id);
    }
}
