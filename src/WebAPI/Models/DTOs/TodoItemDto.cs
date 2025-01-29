using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DTOs
{
    public class TodoItemDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters long")]
        [MaxLength(150, ErrorMessage = "Title cannot exceed 150 characters")]
        public string Title { get; set; }
    }
}
