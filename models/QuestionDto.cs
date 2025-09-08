using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BrightMindQuizApi.Models
{
    public class QuestionDto
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public string? SoundData { get; set; }
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

    // Public response models to match the required JSON exactly
    public class QuestionResponse
    {
        [JsonPropertyName("question_text")]
        public string QuestionText { get; set; } = string.Empty;

        [JsonPropertyName("image_url")]
        public string? ImageUrl { get; set; } = string.Empty; // empty string when no image

        [JsonPropertyName("sound_data")]
        public string? SoundData { get; set; }

        [JsonPropertyName("hint")]
        public string? Hint { get; set; }

        [JsonPropertyName("fun_fact")]
        public string? FunFact { get; set; }

        [JsonPropertyName("options_json")]
        public List<OptionResponse> OptionsJson { get; set; } = new();
    }

    public class OptionResponse
    {
        [JsonPropertyName("option_text")]
        public string OptionText { get; set; } = string.Empty;

        [JsonPropertyName("is_correct")]
        public bool IsCorrect { get; set; }
    }
}
