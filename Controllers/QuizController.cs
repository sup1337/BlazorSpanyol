using BlazorSpanyol.Models.Domain;
using BlazorSpanyol.Models.ViewModels;
using BlazorSpanyol.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlazorSpanyol.Controllers;

public class QuizController : Controller
{
    private readonly IWordsRepository _wordsRepository;
    
    public QuizController(IWordsRepository wordsRepository)
    {
        _wordsRepository = wordsRepository;
    }
    
    // Quiz inditasa 
    [HttpGet]
    [HttpGet]
    public async Task<IActionResult> Index(int numberOfQuestions)
    {
        // Ha a numberOfQuestions <= 0, akkor alapértelmezetten 5 legyen
        if (numberOfQuestions <= 0)
        {
            numberOfQuestions = 5;
        }

        var words = await _wordsRepository.GetRandomWordsAsync(numberOfQuestions);
    
        // Ha nincs elég szó, ki kell jelezni valamit
        if (words.Count < numberOfQuestions)
        {
            ModelState.AddModelError("", "Not enough words available for the quiz.");
            return View("Error");
        }

        var quizQuestions = words.Select(w => new QuizViewModel
        {
            Id = w.Id,
            Hungarian = w.Hungarian,
            English = w.English,
            CorrectSpanish = w.CorrectSpanish
        }).ToList();

        return View(quizQuestions);
    }

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

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
}