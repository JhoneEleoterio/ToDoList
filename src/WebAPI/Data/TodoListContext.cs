using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class TodoListContext: DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
        { }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
