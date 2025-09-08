using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrightMindQuizApi.Data;
using BrightMindQuizApi.Models;
using Microsoft.Extensions.Logging;

namespace BrightMindQuizApi.Controllers;

[ApiController]
[Route("Quizz")]
public class QuizController : ControllerBase
{
    private readonly BrightMindContext _context;
    private readonly ILogger<QuizController> _logger;

    public QuizController(BrightMindContext context, ILogger<QuizController> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet("colors")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetColorsQuiz()
    {
        return await GetQuizQuestions(2);
    }

    [HttpGet("fruits")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetFruitsQuiz()
    {
        return await GetQuizQuestions(3);
    }

    [HttpGet("math")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetMathQuiz()
    {
        return await GetQuizQuestions(8);
    }

    [HttpGet("vegetables")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetVegetablesQuiz()
    {
        return await GetQuizQuestions(6);
    }

    [HttpGet("vehicals")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetVehiclesQuiz()
    {
        return await GetQuizQuestions(7);
    }

    [HttpGet("animalname")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetAnimalQuiz()
    {
        return await GetQuizQuestions(4);
    }

    [HttpGet("birds")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetBirdQuiz()
    {
        return await GetQuizQuestions(5);
    }
    [HttpGet("Sounds")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetSoundQuiz()
    {
        return await GetQuizQuestions(10);
    }

    private async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuizQuestions(int quizId)
    {
        try
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            var questions = await _context.Questions
                .Where(q => q.QuizId == quizId)
                .Include(q => q.QuestionOptions)
                .ThenInclude(qo => qo.Option)
                .Select(q => new QuestionDto
                {
                    QuestionId = q.QuestionId,
                    QuestionText = q.QuestionText,
                    ImageUrl = string.IsNullOrEmpty(q.ImageUrl)
                        ? null
                        : $"{baseUrl}/images/{q.ImageUrl.Replace("assets/", "").Replace("images/", "").TrimStart('/')}",
                    SoundData = q.SoundData != null
                        ? $"/sounds/{Path.GetFileName(q.SoundData)}"
                        : null,
                    Hint = q.Hint,
                    FunFact = q.FunFact,
                    Options = q.QuestionOptions.Select(qo => new OptionDto
                    {
                        OptionId = qo.OptionId,
                        OptionText = qo.Option != null ? qo.Option.OptionText : "Missing Option",
                        IsCorrect = qo.IsCorrect
                    }).ToList()
                })
                .ToListAsync();

            if (!questions.Any())
            {
                return NotFound($"No questions found for quiz ID {quizId}.");
            }

            return Ok(questions);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching questions for QuizId {QuizId}", quizId);
            return StatusCode(500, "An error occurred while fetching quiz questions. Please try again later.");
        }
    }
}