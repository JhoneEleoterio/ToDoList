using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class TodoService(TodoListContext context) : ITodoService
    {
        private readonly TodoListContext _context = context;

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        => await _context.TodoItems.OrderByDescending(order => order.CreatedAt).ToListAsync();

        public async Task<TodoItem?> GetByIdAsync(Guid id)
            => await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Guid> AddAsync(TodoItem todoItem)
        {
            await _context.TodoItems.AddAsync(todoItem);
            await _context.SaveChangesAsync();

            return todoItem.Id;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var todoItem = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);
            
            if (todoItem is null) return Guid.Empty;

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return todoItem.Id;
        }

        public async Task<bool> MarkCompleteAsync(Guid id)
        {
            var item = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);
            
            if (item is null) return false;
            
            item.MarkComplete();

            _context.TodoItems.Update(item);
            await _context.SaveChangesAsync();

            return item.IsComplete;
        }
    }
}
