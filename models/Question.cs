using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrightMindQuizApi.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]
        public int QuizId { get; set; }

        [MaxLength(500)]
        [Required]
        public string QuestionText { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? ImageUrl { get; set; }

       [MaxLength(500)] // Added to limit URL/path length
        public string? SoundData { get; set; } 

        [MaxLength(500)]
        public string? Hint { get; set; }

        [MaxLength(1000)]
        public string? FunFact { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("QuizId")]
        public Quiz? Quiz { get; set; }

        public List<QuestionOption> QuestionOptions { get; set; } = new List<QuestionOption>(); // Non-nullable with default empty list
    }
}