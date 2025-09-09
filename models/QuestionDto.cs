using System.ComponentModel.DataAnnotations;
namespace BrightMindQuizApi.Models
{
    public class QuestionDto
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
       public string? SoundUrl { get; set; }
        public string? Hint { get; set; }
        public string? FunFact { get; set; }

        public List<OptionDto> Options { get; set; } = new();
    }

    public class OptionDto
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
    }
}
