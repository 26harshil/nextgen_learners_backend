
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

    /// <summary>Get Color Trivia questions (Category ID: 2)</summary>
    /// <remarks>Returns all questions and options for the Color Trivia quiz.</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("colors")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetColorsQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 2,
            quizTitleCandidates: ["Learn Colors with Fun", "Color Trivia"]
        );
    }

    /// <summary>Get Fruit Trivia questions (Category ID: 3)</summary>
    /// <remarks>Returns all questions and options for the Fruit Trivia quiz.</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("fruits")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetFruitsQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 3,
            quizTitleCandidates: ["Fruit Fiesta", "Fruit Trivia"]
        );
    }

    /// <summary>Get Math for Kids questions (Category ID: 1)</summary>
    /// <remarks>Returns all questions and options for the Math for Kids quiz.</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("math")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetMathQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 1,
            quizTitleCandidates: ["Math Mastery", "Math for Kids"]
        );
    }

    /// <summary>Get Vegetable Trivia questions (Category ID: 6)</summary>
    /// <remarks>Returns all questions and options for the Vegetable Trivia quiz.</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("vegetables")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetVegetablesQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 6,
            quizTitleCandidates: ["Vegetable Adventure", "Vegetable Trivia"]
        );
    }

    /// <summary>Get Vehicle Trivia questions (Category ID: 7)</summary>
    /// <remarks>Returns all questions and options for the Vehicle Trivia quiz.</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("vehicles")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetVehiclesQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 7,
            quizTitleCandidates: ["Vehicles World", "Vehicle Trivia"]
        );
    }

    /// <summary>Get Ground Animal Trivia questions (Category ID: 4)</summary>
    /// <remarks>Returns all questions and options for the Ground Animal Trivia quiz.</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("animalname")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetAnimalQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 4,
            quizTitleCandidates: ["Ground Animal Trivia", "Animal Name"]
        );
    }

    /// <summary>Get Bird Trivia questions (Category ID: 5)</summary>
    /// <remarks>Returns all questions and options for the Bird Trivia quiz.</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("birds")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetBirdQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 5,
            quizTitleCandidates: ["Bird", "Bird Trivia"]
        );
    }

    /// <summary>Get Animal Sounds questions (Category ID: 25)</summary>
    /// <remarks>Returns all questions and options for the Animal Sounds quiz.</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("sounds")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetSoundQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 25,
            quizTitleCandidates: ["Animal Sounds", "Sounds"]
        );
    }

    /// <summary>Get Animal Homes &amp; Babies questions (Category ID: 27)</summary>
    /// <remarks>Returns all questions and options for the Animal Homes &amp; Babies quiz.</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("animalhomes")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetAnimalHomesQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 27,
            quizTitleCandidates: ["Animal Homes & Babies", "Nature Explorer"]
        );
    }

    /// <summary>Get Musical Instruments questions (Category ID: 28)</summary>
    /// <remarks>Returns all questions and options for the Musical Instruments quiz.</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("musicalinstruments")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetMusicalInstrumentsQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 28,
            quizTitleCandidates: ["Musical Instruments", "The Music Room"]
        );
    }

    /// <summary>Get Emotions &amp; Feelings questions (Category ID: 16)</summary>
    /// <remarks>Returns all questions and options for the Emotions &amp; Feelings quiz.</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("emotions")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetEmotionsQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 16,
            quizTitleCandidates: ["Emotions & Feelings", "How Do You Feel?"]
        );
    }

    /// <summary>Get Opposites questions (Category ID: 15)</summary>
    /// <remarks>Returns all questions and options for the Opposites quiz.</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("opposites")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetOppositesQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 15,
            quizTitleCandidates: ["Opposites", "Opposite Day"]
        );
    }

    /// <summary>Get Weather and Seasons questions (Category ID: 14)</summary>
    /// <remarks>Returns all questions and options for the Weather and Seasons quiz.</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("weather")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetWeatherQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 14,
            quizTitleCandidates: ["Weather and Seasons", "Weather Watcher"]
        );
    }

    /// <summary>Get Ocean Life questions (Category ID: 26)</summary>
    /// <remarks>Returns all questions and options for the Ocean Life quiz (Wonders of the Ocean).</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("ocenlife")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetOceanLifeQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 26,
            quizTitleCandidates: ["Wonders of the Ocean", "Ocean Life and Animals", "Ocean Life"]
        );
    }

    /// <summary>Get Community Helpers questions (Category ID: 29)</summary>
    /// <remarks>Returns all questions and options for the Community Helpers quiz.</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("communityhelpers")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetCommunityHelpersQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 29,
            quizTitleCandidates: ["Community Helpers", "Who Helps Us?"]
        );
    }

    /// <summary>Get Body Parts questions (Category ID: 12)</summary>
    /// <remarks>Returns all questions and options for the Body Parts quiz.</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("bodyparts")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetBodyPartsQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 12,
            quizTitleCandidates: ["Body Parts", "All About Me"]
        );
    }

    /// <summary>Get Basic Shapes questions (Category ID: 11)</summary>
    /// <remarks>Returns all questions and options for the Basic Shapes quiz.</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("basicshapes")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetBasicShapesQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 11,
            quizTitleCandidates: ["Basic Shapes", "Shape Explorer"]
        );
    }

    /// <summary>Get Baby Animals questions (Category ID: 19)</summary>
    /// <remarks>Returns all questions and options for the Baby Animals quiz.</remarks>
    /// <response code="200">List of quiz questions with options</response>
    /// <response code="404">No questions found for this quiz</response>
    [HttpGet("babyanimals")]
    [ProducesResponseType(typeof(IEnumerable<QuestionDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetBabyAnimalsQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 19,
            quizTitleCandidates: ["Baby Animals", "Baby Animal Trivia", "Baby Animal"]
        );
    }

    private async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuizQuestions(
        int fallbackQuizId,
        params string[] quizTitleCandidates
    )
    {
        int quizId = fallbackQuizId;
        try
        {
            quizId = await ResolveQuizIdAsync(fallbackQuizId, quizTitleCandidates);
            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            // Fetch raw data from DB first (no string manipulation in SQL)
            var rawQuestions = await _context.Questions
                .Where(q => q.QuizId == quizId)
                .Include(q => q.QuestionOptions)
                .ThenInclude(qo => qo.Option)
                .ToListAsync();

            // Do string transformations in-memory (C#), not in PostgreSQL SQL
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

            if (!questions.Any())
            {
                return NotFound($"No questions found for quiz ID {quizId}.");
            }

            return Ok(questions);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching questions for QuizId {quizId}: {ex.Message}");
            return StatusCode(500, $"An error occurred while fetching quiz questions: {ex.Message}");
        }
    }

    private async Task<int> ResolveQuizIdAsync(int fallbackQuizId, params string[] quizTitleCandidates)
    {
        if (quizTitleCandidates == null || quizTitleCandidates.Length == 0)
        {
            return fallbackQuizId;
        }

        var normalizedCandidates = quizTitleCandidates
            .Where(c => !string.IsNullOrWhiteSpace(c))
            .Select(c => c.Trim())
            .ToList();

        if (!normalizedCandidates.Any())
        {
            return fallbackQuizId;
        }

        // Prefer most recently inserted quiz when titles collide.
        var quizzes = await _context.Quizzes
            .AsNoTracking()
            .OrderByDescending(q => q.QuizId)
            .ToListAsync();

        foreach (var candidate in normalizedCandidates)
        {
            var exactMatch = quizzes.FirstOrDefault(q =>
                string.Equals(q.QuizTitle, candidate, StringComparison.OrdinalIgnoreCase)
            );

            if (exactMatch != null)
            {
                return exactMatch.QuizId;
            }
        }

        foreach (var candidate in normalizedCandidates)
        {
            var containsMatch = quizzes.FirstOrDefault(q =>
                q.QuizTitle.Contains(candidate, StringComparison.OrdinalIgnoreCase)
            );

            if (containsMatch != null)
            {
                return containsMatch.QuizId;
            }
        }

        return fallbackQuizId;
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