using BlazorSpanyol.Data;
using BlazorSpanyol.Models.Domain;
using BlazorSpanyol.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlazorSpanyol.Controllers;

public class QuizController : Controller
{
    private readonly SpanishDbContext _spanishDbContext;

    public QuizController(SpanishDbContext spanishDbContext)
    {
        _spanishDbContext = spanishDbContext;
    }
    
    // Quiz inditasa 
    public IActionResult Index(int numberOfQuestions = 2)
    {
        var words = _spanishDbContext.Words
            .OrderBy(w => Guid.NewGuid())
            .Take(numberOfQuestions)
            .Select(w => new Quiz()
            {
                Id = w.Id,
                Hungarian = w.Hungarian,
                English = w.English,
                CorrectSpanish = w.CorrectSpanish
            }).ToList();
        return View(words);
    }

    [HttpPost]
    public IActionResult Evaluate(List<Quiz> quizAnswers)
    {
        var results = quizAnswers.Select(q => new QuizResultViewModel()
        {
            Hungarian = q.Hungarian,
            English = q.English,
            UserAnswer = q.UserAnswer,
            CorrectSpanish = q.CorrectSpanish,
            IsCorrect = q.IsCorrect
        }).ToList();
        
        return View("Results" ,results);
    }
}