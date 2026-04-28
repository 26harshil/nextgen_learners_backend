
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrightMindQuizApi.Data;
using BrightMindQuizApi.Models;

namespace BrightMindQuizApi.Controllers;

[ApiController]
[Route("Quizz")]
public class QuizController : ControllerBase
{
    private readonly BrightMindContext _context;

    public QuizController(BrightMindContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>Get quiz questions by Category ID</summary>
    /// <remarks>
    /// Returns all questions and options for the quiz matching the given category ID.
    ///
    /// **Category ID Reference:**
    ///
    /// | ID | Category |
    /// |---|---|
    /// | 1 | Math for Kids |
    /// | 2 | Color Trivia |
    /// | 3 | Fruit Trivia |
    /// | 4 | Ground Animal Trivia |
    /// | 5 | Bird Trivia |
    /// | 6 | Vegetable Trivia |
    /// | 7 | Vehicle Trivia |
    /// | 11 | Basic Shapes |
    /// | 12 | Body Parts |
    /// | 14 | Weather and Seasons |
    /// | 15 | Opposites |
    /// | 16 | Emotions &amp; Feelings |
    /// | 19 | Baby Animals |
    /// | 26 | Ocean Life |
    /// | 27 | Animal Homes &amp; Babies |
    /// | 28 | Musical Instruments |
    /// | 29 | Community Helpers |
    /// </remarks>
    /// <param name="categoryId">The numeric category ID (e.g. 1 for Math, 4 for Ground Animals)</param>
    /// <response code="200">List of quiz questions with multiple choice options</response>
    /// <response code="404">No quiz or questions found for this category ID</response>
    /// <response code="500">Server error while fetching quiz data</response>
    [HttpGet("{categoryId:int}")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuizByCategory(int categoryId)
    {
        try
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            // Find the most recently inserted quiz for this category
            var quiz = await _context.Quizzes
                .AsNoTracking()
                .Where(q => q.CategoryId == categoryId)
                .OrderByDescending(q => q.QuizId)
                .FirstOrDefaultAsync();

            if (quiz == null)
            {
                return NotFound($"No quiz found for category ID {categoryId}.");
            }

            // Fetch all questions for this quiz
            var rawQuestions = await _context.Questions
                .Where(q => q.QuizId == quiz.QuizId)
                .Include(q => q.QuestionOptions)
                .ThenInclude(qo => qo.Option)
                .ToListAsync();

            if (!rawQuestions.Any())
            {
                return NotFound($"No questions found for category ID {categoryId} (quiz: \"{quiz.QuizTitle}\", quiz_id: {quiz.QuizId}).");
            }

            var questions = rawQuestions.Select(q => new QuestionDto
            {
                QuestionId = q.QuestionId,
                QuestionText = q.QuestionText,
                ImageUrl = string.IsNullOrEmpty(q.ImageUrl)
                    ? null
                    : BuildImageUrl(baseUrl, q.ImageUrl),
                SoundUrl = string.IsNullOrEmpty(q.SoundUrl)
                    ? null
                    : BuildSoundUrl(baseUrl, q.SoundUrl),
                Hint = q.Hint,
                FunFact = q.FunFact,
                Options = q.QuestionOptions.Select(qo => new OptionDto
                {
                    OptionId = qo.OptionId,
                    OptionText = qo.Option != null ? qo.Option.OptionText : "Missing Option",
                    IsCorrect = qo.IsCorrect
                }).ToList()
            }).ToList();

            return Ok(questions);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching questions for category ID {categoryId}: {ex.Message}");
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    private static string BuildImageUrl(string baseUrl, string rawImagePath)
    {
        var normalized = rawImagePath.Trim().Replace("\\", "/");

        if (normalized.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
            normalized.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            return normalized;
        }

        // Flutter local asset path — return as-is so the app loads it from the bundle
        if (normalized.StartsWith("assets/", StringComparison.OrdinalIgnoreCase))
        {
            return normalized;
        }

        normalized = normalized
            .Replace("images/", "", StringComparison.OrdinalIgnoreCase)
            .TrimStart('/');

        return $"{baseUrl}/images/{normalized}";
    }

    private static string BuildSoundUrl(string baseUrl, string rawSoundPath)
    {
        var normalized = rawSoundPath.Trim().Replace("\\", "/");

        if (normalized.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
            normalized.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            return normalized;
        }

        normalized = normalized
            .Replace("assets/sounds/", "", StringComparison.OrdinalIgnoreCase)
            .Replace("assets/sound/", "", StringComparison.OrdinalIgnoreCase)
            .Replace("/sounds/", "", StringComparison.OrdinalIgnoreCase)
            .Replace("/sound/", "", StringComparison.OrdinalIgnoreCase)
            .Replace("sounds/", "", StringComparison.OrdinalIgnoreCase)
            .Replace("sound/", "", StringComparison.OrdinalIgnoreCase)
            .TrimStart('/');

        return $"{baseUrl}/sounds/{normalized}";
    }
}