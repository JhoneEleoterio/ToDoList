using WebAPI.Models;

namespace WebAPI.Services
{
    public class TodoService: ITodoService
    {
        private readonly List<TodoItem> _todoItems = new();

        public IEnumerable<TodoItem> GetAll()
        => _todoItems;

        public TodoItem? GetById(Guid id)
        => _todoItems.FirstOrDefault(x => x.Id == id);  

        public void Add(TodoItem todoItem)
        {
            _todoItems.Add(todoItem);   
        }

        public bool Delete(Guid id)
        {
            var item = _todoItems.FirstOrDefault(x => x.Id == id);
            
            if (item == null) return false;

            _todoItems.Remove(item);

            return true;
        }

        public bool MarkComplete(Guid id)
        {
            var item = _todoItems.FirstOrDefault(x => x.Id == id);
            if (item == null) return false;

            item.MarkComplete();
            return item.IsComplete;
        }
    }
}
