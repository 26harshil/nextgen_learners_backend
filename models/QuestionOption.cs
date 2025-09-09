using System.ComponentModel.DataAnnotations;

namespace BrightMindQuizApi.Models
{
    public class QuestionOption
    {
        [Key]
        public int QuestionOptionId { get; set; }

        public int QuestionId { get; set; }
        public int OptionId { get; set; }

        public bool IsCorrect { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Question? Question { get; set; }
        public OptionPool? Option { get; set; }
    }
}

