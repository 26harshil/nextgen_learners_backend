using System.ComponentModel.DataAnnotations;

namespace BrightMindQuizApi.Models
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }

        [MaxLength(200), Required]
        public string QuizTitle { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Category? Category { get; set; }
        public List<Question>? Questions { get; set; }
    }
}
