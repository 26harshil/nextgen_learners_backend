using System.ComponentModel.DataAnnotations;

namespace BrightMindQuizApi.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [MaxLength(100), Required]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Quiz>? Quizzes { get; set; }
    }
}
