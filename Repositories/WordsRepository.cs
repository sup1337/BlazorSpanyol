using BlazorSpanyol.Data;
using BlazorSpanyol.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorSpanyol.Repositories;

public class WordsRepository : IWordsRepository
{
    private readonly SpanishDbContext _spanishDbContext;

    public WordsRepository(SpanishDbContext spanishDbContext)
    {
        _spanishDbContext = spanishDbContext;
    }

    public async Task<IEnumerable<Words>> GetAllWordsAsync()
    {
        return await _spanishDbContext.Words.ToListAsync();
    }

    public Task<Words?> GetWordAsync(Guid id)
    {
        return _spanishDbContext.Words.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Words> AddWordAsync(Words word)
    {
        await _spanishDbContext.Words.AddAsync(word);
        await _spanishDbContext.SaveChangesAsync();
        return word;
    }

    public async Task<Words?> UpdateWordAsync(Words word)
    {
       var existingWord = await _spanishDbContext.Words.FirstOrDefaultAsync(x => x.Id == word.Id);
       
       if(existingWord != null)
       {
           existingWord.CorrectSpanish = word.CorrectSpanish;
           existingWord.English = word.English;
           existingWord.Hungarian = word.Hungarian;
           await _spanishDbContext.SaveChangesAsync();
           return existingWord;
       }

       return null;
    }

    public async Task<Words?> DeleteWordAsync(Guid id)
    {
        var existingWord = await _spanishDbContext.Words.FindAsync(id);
        
        if(existingWord != null)
        {
            _spanishDbContext.Words.Remove(existingWord);
            await _spanishDbContext.SaveChangesAsync();
            return existingWord;
        }

        return null;
    }
    public async Task<List<Words>> GetRandomWordsAsync(int count)
    {
        var totalWords = await _spanishDbContext.Words.CountAsync();
        if (count > totalWords)
        {
            count = totalWords;
        }
        return await _spanishDbContext.Words.OrderBy(words => Guid.NewGuid() ).Take(count).ToListAsync();
    }
}