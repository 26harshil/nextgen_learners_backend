
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

    [HttpGet("colors")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetColorsQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 2,
            quizTitleCandidates: ["Learn Colors with Fun", "Color Trivia"]
        );
    }

    [HttpGet("fruits")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetFruitsQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 3,
            quizTitleCandidates: ["Fruit Fiesta", "Fruit Trivia"]
        );
    }

    [HttpGet("math")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetMathQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: ,8
            quizTitleCandidates: ["Math Mastery", "Math for Kids"]
        );
    }

    [HttpGet("vegetables")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetVegetablesQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 6,
            quizTitleCandidates: ["Vegetable Adventure", "Vegetable Trivia"]
        );
    }

    [HttpGet("vehicles")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetVehiclesQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 7,
            quizTitleCandidates: ["Vehicles World", "Vehicle Trivia"]
        );
    }

    [HttpGet("animalname")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetAnimalQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 4,
            quizTitleCandidates: ["Ground Animal Trivia", "Animal Name"]
        );
    }

    [HttpGet("birds")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetBirdQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 5,
            quizTitleCandidates: ["Bird", "Bird Trivia"]
        );
    }

    [HttpGet("sounds")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetSoundQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 25,
            quizTitleCandidates: ["Animal Sounds", "Sounds"]
        );
    }

    [HttpGet("animalhomes")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetAnimalHomesQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 27,
            quizTitleCandidates: ["Animal Homes & Babies", "Nature Explorer"]
        );
    }

    [HttpGet("musicalinstruments")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetMusicalInstrumentsQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId:28,
            quizTitleCandidates: ["Musical Instruments", "The Music Room"]
        );
    }

    [HttpGet("emotions")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetEmotionsQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 16,
            quizTitleCandidates: ["Emotions & Feelings", "How Do You Feel?"]
        );
    }

    [HttpGet("opposites")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetOppositesQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 15,
            quizTitleCandidates: ["Opposites", "Opposite Day"]
        );
    }

    [HttpGet("weather")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetWeatherQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 14,
            quizTitleCandidates: ["Weather and Seasons", "Weather Watcher"]
        );
    }
    [HttpGet("ocenlife")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetOceanLifeQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 26,
            quizTitleCandidates: ["Wonders of the Ocean", "Ocean Life and Animals", "Ocean Life"]
        );
    }

    [HttpGet("communityhelpers")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetCommunityHelpersQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 29,
            quizTitleCandidates: ["Community Helpers", "Who Helps Us?"]
        );
    }

    [HttpGet("bodyparts")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetBodyPartsQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 12,
            quizTitleCandidates: ["Body Parts", "All About Me"]
        );
    }

    [HttpGet("basicshapes")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetBasicShapesQuiz()
    {
        return await GetQuizQuestions(
            fallbackQuizId: 11,
            quizTitleCandidates: ["Basic Shapes", "Shape Explorer"]
        );
    }

    [HttpGet("babyanimals")]
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