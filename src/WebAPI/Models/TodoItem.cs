using WebAPI.Models.Shared;

namespace WebAPI.Models
{
    public class TodoItem: ModelBase
    {
        public string? Title { get; private set; }
        public bool IsComplete { get; private set; }

        protected TodoItem()
        {
            IsComplete = false;
        }

        public TodoItem(string title) : this()  => Title = title;

        public void MarkComplete()
        {
            IsComplete = true;
        }
    }
}
