
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

    /// <summary>Maps the URL name to its database category_id.</summary>
    private static readonly Dictionary<string, int> _nameToCategoryId = new(StringComparer.OrdinalIgnoreCase)
    {
        { "math",                1  },
        { "colors",              2  },
        { "fruits",              3  },
        { "animalname",          4  },
        { "birds",               5  },
        { "vegetables",          6  },
        { "vehicles",            7  },
        { "basicshapes",         11 },
        { "bodyparts",           12 },
        { "weather",             14 },
        { "opposites",           15 },
        { "emotions",            16 },
        { "babyanimals",         27 },
        { "ocenlife",            26 },
        { "musicalinstruments",  28 },
        { "communityhelpers",    29 },
    };

    public QuizController(BrightMindContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>Get quiz questions by quiz name</summary>
    /// <remarks>
    /// Returns all questions and options for the named quiz category.
    /// Each name maps to a category ID in the database.
    ///
    /// **Available names and their category IDs:**
    ///
    /// | URL Name | Category | DB Category ID |
    /// |---|---|---|
    /// | `math` | Math for Kids | 1 |
    /// | `colors` | Color Trivia | 2 |
    /// | `fruits` | Fruit Trivia | 3 |
    /// | `animalname` | Ground Animal Trivia | 4 |
    /// | `birds` | Bird Trivia | 5 |
    /// | `vegetables` | Vegetable Trivia | 6 |
    /// | `vehicles` | Vehicle Trivia | 7 |
    /// | `basicshapes` | Basic Shapes | 11 |
    /// | `bodyparts` | Body Parts | 12 |
    /// | `weather` | Weather and Seasons | 14 |
    /// | `opposites` | Opposites | 15 |
    /// | `emotions` | Emotions &amp; Feelings | 16 |
    /// | `babyanimals` | Baby Animals &amp; Homes | 27 |
    /// | `ocenlife` | Ocean Life | 26 |
    /// | `musicalinstruments` | Musical Instruments | 28 |
    /// | `communityhelpers` | Community Helpers | 29 |
    ///
    /// **Example:** `GET /Quizz/math` returns all Math for Kids questions.
    /// </remarks>
    /// <param name="quizName">The quiz name (e.g. math, colors, animalname, ocenlife)</param>
    /// <response code="200">List of quiz questions with multiple choice options</response>
    /// <response code="400">Unknown quiz name — not in the supported list</response>
    /// <response code="404">No quiz or questions found for this category</response>
    /// <response code="500">Server error while fetching quiz data</response>
    [HttpGet("{quizName}")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuiz(string quizName)
    {
        if (!_nameToCategoryId.TryGetValue(quizName, out var categoryId))
        {
            var validNames = string.Join(", ", _nameToCategoryId.Keys.OrderBy(k => k));
            return BadRequest($"Unknown quiz name \"{quizName}\". Valid names: {validNames}");
        }

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
                return NotFound($"No quiz found for \"{quizName}\" (category ID: {categoryId}).");
            }

            // Fetch all questions for this quiz
            var rawQuestions = await _context.Questions
                .Where(q => q.QuizId == quiz.QuizId)
                .Include(q => q.QuestionOptions)
                .ThenInclude(qo => qo.Option)
                .ToListAsync();

            if (!rawQuestions.Any())
            {
                return NotFound($"No questions found for \"{quizName}\" (quiz: \"{quiz.QuizTitle}\", quiz_id: {quiz.QuizId}).");
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
            Console.WriteLine($"Error fetching quiz \"{quizName}\" (category {categoryId}): {ex.Message}");
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