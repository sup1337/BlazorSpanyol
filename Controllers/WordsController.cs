using BlazorSpanyol.Models.Domain;
using BlazorSpanyol.Models.ViewModels;
using BlazorSpanyol.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlazorSpanyol.Controllers;

public class WordsController : Controller
{
    private readonly IWordsRepository _wordsRepository;

    public WordsController(IWordsRepository wordsRepository)
    {
        _wordsRepository = wordsRepository;
    }
    // GET
    
    [HttpGet]
    public async Task<IActionResult> Add()
    {
        return View();
    }

    [HttpPost]
    [ActionName("Add")]
    public async Task<IActionResult> Add(AddWordRequest addWordRequest)
    {
        var word = new Words
        {
            Hungarian = addWordRequest.Hungarian,
            English = addWordRequest.English,
            CorrectSpanish = addWordRequest.CorrectSpanish
        };
        await _wordsRepository.AddWordAsync(word);
        return RedirectToAction("List");
    }
    
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var words = await _wordsRepository.GetAllWordsAsync();
        return View(words);
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var words = await _wordsRepository.GetWordAsync(id);
            
        if (words != null)
        {
            var editWordsRequest = new EditWordsRequest
            {
               Id = words.Id,
                Hungarian = words.Hungarian,
                English = words.English,
                CorrectSpanish = words.CorrectSpanish
            };

            return View(editWordsRequest);
        }

        return View(null);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(EditWordsRequest editWordsRequest)
    {
        var word = new Words
        {
            Id = editWordsRequest.Id,
            Hungarian = editWordsRequest.Hungarian,
            English = editWordsRequest.English,
            CorrectSpanish = editWordsRequest.CorrectSpanish
        };

        var updatedWord = await _wordsRepository.UpdateWordAsync(word);

        if (updatedWord != null)
        {
            // Show success notification
        }
        else
        {
            // Show error notification
        }

        return RedirectToAction("List", new { id = editWordsRequest.Id });
    }
   
    
}