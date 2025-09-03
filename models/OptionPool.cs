using System.ComponentModel.DataAnnotations;

namespace BrightMindQuizApi.Models
{
    public class OptionPool
    {
        [Key]
        public int OptionId { get; set; }

        [MaxLength(200), Required]
        public string OptionText { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<QuestionOption>? QuestionOptions { get; set; }
    }
}
