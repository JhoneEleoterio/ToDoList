namespace WebAPI.Models.Shared
{
    public class ModelBase
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
    }
}
