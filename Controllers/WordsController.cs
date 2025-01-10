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
            Italian = addWordRequest.Italian,
            French = addWordRequest.French,
            German = addWordRequest.German,
            Infinitive = addWordRequest.Infinitive,
            Gerund = addWordRequest.Gerund,
            Participle = addWordRequest.Participle,
            Present1 = addWordRequest.Present1,
            Present2 = addWordRequest.Present2,
            Present3 = addWordRequest.Present3,
            Present4 = addWordRequest.Present4,
            Present5 = addWordRequest.Present5,
            Present6 = addWordRequest.Present6,
            Imperfect1 = addWordRequest.Imperfect1,
            Imperfect2 = addWordRequest.Imperfect2,
            Imperfect3 = addWordRequest.Imperfect3,
            Imperfect4 = addWordRequest.Imperfect4,
            Imperfect5 = addWordRequest.Imperfect5,
            Imperfect6 = addWordRequest.Imperfect6,
            Indefinite1 = addWordRequest.Indefinite1,
            Indefinite2 = addWordRequest.Indefinite2,
            Indefinite3 = addWordRequest.Indefinite3,
            Indefinite4 = addWordRequest.Indefinite4,
            Indefinite5 = addWordRequest.Indefinite5,
            Indefinite6 = addWordRequest.Indefinite6,
            Future1 = addWordRequest.Future1,
            Future2 = addWordRequest.Future2,
            Future3 = addWordRequest.Future3,
            Future4 = addWordRequest.Future4,
            Future5 = addWordRequest.Future5,
            Future6 = addWordRequest.Future6,
            Conditional1 = addWordRequest.Conditional1,
            Conditional2 = addWordRequest.Conditional2,
            Conditional3 = addWordRequest.Conditional3,
            Conditional4 = addWordRequest.Conditional4,
            Conditional5 = addWordRequest.Conditional5,
            Conditional6 = addWordRequest.Conditional6,
            SubjunctivePresent1 = addWordRequest.SubjunctivePresent1,
            SubjunctivePresent2 = addWordRequest.SubjunctivePresent2,
            SubjunctivePresent3 = addWordRequest.SubjunctivePresent3,
            SubjunctivePresent4 = addWordRequest.SubjunctivePresent4,
            SubjunctivePresent5 = addWordRequest.SubjunctivePresent5,
            SubjunctivePresent6 = addWordRequest.SubjunctivePresent6,
            SubjunctiveImperfect1 = addWordRequest.SubjunctiveImperfect1,
            SubjunctiveImperfect2 = addWordRequest.SubjunctiveImperfect2,
            SubjunctiveImperfect3 = addWordRequest.SubjunctiveImperfect3,
            SubjunctiveImperfect4 = addWordRequest.SubjunctiveImperfect4,
            SubjunctiveImperfect5 = addWordRequest.SubjunctiveImperfect5,
            SubjunctiveImperfect6 = addWordRequest.SubjunctiveImperfect6,
            ImperativePositive2 = addWordRequest.ImperativePositive2,
            ImperativePositive3 = addWordRequest.ImperativePositive3,
            ImperativePositive4 = addWordRequest.ImperativePositive4,
            ImperativePositive5 = addWordRequest.ImperativePositive5,
            ImperativePositive6 = addWordRequest.ImperativePositive6,
            ImperativeNegative2 = addWordRequest.ImperativeNegative2,
            ImperativeNegative3 = addWordRequest.ImperativeNegative3,
            ImperativeNegative4 = addWordRequest.ImperativeNegative4,
            ImperativeNegative5 = addWordRequest.ImperativeNegative5,
            ImperativeNegative6 = addWordRequest.ImperativeNegative6,
            
            
            
            
            
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
                Infinitive = words.Infinitive
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
            Infinitive = editWordsRequest.Infinitive
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

    [HttpPost]
    public async Task<IActionResult> Delete(EditWordsRequest editWordsRequest)
    {
        var deletedWord = await _wordsRepository.DeleteWordAsync(editWordsRequest.Id);

        if (deletedWord != null)
        {
            // Show success notification
            return RedirectToAction("List");
        }

        // Show an error notification
        return RedirectToAction("Edit", new { id = editWordsRequest.Id });
    }
}