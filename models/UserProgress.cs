using System.ComponentModel.DataAnnotations;

namespace BrightMindQuizApi.Models
{
    public class UserProgress
    {
        [Key]
        public int ProgressId { get; set; }

        public int UserId { get; set; }
        public int QuizId { get; set; }
        public int QuestionId { get; set; }

        public bool IsCorrect { get; set; }

        public DateTime AttemptDate { get; set; }

        public Quiz? Quiz { get; set; }
        public Question? Question { get; set; }
    }
}
