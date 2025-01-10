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
           existingWord.Infinitive = word.Infinitive;
           existingWord.English = word.English;
           existingWord.Hungarian = word.Hungarian;
           existingWord.Italian = word.Italian;
           existingWord.French = word.French;
           existingWord.German = word.German;
           existingWord.Gerund = word.Gerund;
           existingWord.Participle = word.Participle;
           existingWord.Present1 = word.Present1;
           existingWord.Present2 = word.Present2;
           existingWord.Present3 = word.Present3;
           existingWord.Present4 = word.Present4;
           existingWord.Present5 = word.Present5;
           existingWord.Present6 = word.Present6;
           existingWord.Imperfect1 = word.Imperfect1;
           existingWord.Imperfect2 = word.Imperfect2;
           existingWord.Imperfect3 = word.Imperfect3;
           existingWord.Imperfect4 = word.Imperfect4;
           existingWord.Imperfect5 = word.Imperfect5;
           existingWord.Imperfect6 = word.Imperfect6;
           existingWord.Indefinite1 = word.Indefinite1;
           existingWord.Indefinite2 = word.Indefinite2;
           existingWord.Indefinite3 = word.Indefinite3;
           existingWord.Indefinite4 = word.Indefinite4;
           existingWord.Indefinite5 = word.Indefinite5;
           existingWord.Indefinite6 = word.Indefinite6;
           existingWord.Future1 = word.Future1;
           existingWord.Future2 = word.Future2;
           existingWord.Future3 = word.Future3;
           existingWord.Future4 = word.Future4;
           existingWord.Future5 = word.Future5;
           existingWord.Future6 = word.Future6;
           existingWord.Conditional1 = word.Conditional1;
           existingWord.Conditional2 = word.Conditional2;
           existingWord.Conditional3 = word.Conditional3;
           existingWord.Conditional4 = word.Conditional4;
           existingWord.Conditional5 = word.Conditional5;
           existingWord.Conditional6 = word.Conditional6;
           existingWord.SubjunctivePresent1 = word.SubjunctivePresent1;
           existingWord.SubjunctivePresent2 = word.SubjunctivePresent2;
           existingWord.SubjunctivePresent3 = word.SubjunctivePresent3;
           existingWord.SubjunctivePresent4 = word.SubjunctivePresent4;
           existingWord.SubjunctivePresent5 = word.SubjunctivePresent5;
           existingWord.SubjunctivePresent6 = word.SubjunctivePresent6;
           existingWord.SubjunctiveImperfect1 = word.SubjunctiveImperfect1;
           existingWord.SubjunctiveImperfect2 = word.SubjunctiveImperfect2;
           existingWord.SubjunctiveImperfect3 = word.SubjunctiveImperfect3;
           existingWord.SubjunctiveImperfect4 = word.SubjunctiveImperfect4;
           existingWord.SubjunctiveImperfect5 = word.SubjunctiveImperfect5;
           existingWord.SubjunctiveImperfect6 = word.SubjunctiveImperfect6;
           existingWord.ImperativePositive2 = word.ImperativePositive2;
           existingWord.ImperativePositive3 = word.ImperativePositive3;
           existingWord.ImperativePositive4 = word.ImperativePositive4;
           existingWord.ImperativePositive5 = word.ImperativePositive5;
           existingWord.ImperativePositive6 = word.ImperativePositive6;
           existingWord.ImperativeNegative2 = word.ImperativeNegative2;
           existingWord.ImperativeNegative3 = word.ImperativeNegative3;
           existingWord.ImperativeNegative4 = word.ImperativeNegative4;
           existingWord.ImperativeNegative5 = word.ImperativeNegative5;
           existingWord.ImperativeNegative6 = word.ImperativeNegative6;
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