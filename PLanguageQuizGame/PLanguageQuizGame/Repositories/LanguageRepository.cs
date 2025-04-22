using Microsoft.EntityFrameworkCore;
using PLanguageQuizGame.Data;
using PLanguageQuizGame.Interfaces;
using PLanguageQuizGame.Models;

namespace PLanguageQuizGame.Repositories;

public class LanguageRepository : ILanguageRepository
{
    private QuizgameDbContext dbContext;

    public LanguageRepository(QuizgameDbContext dbContext)
    {
        this.dbContext = dbContext;
    }


    public async Task<IEnumerable<Language>> GetLanguagesWithQuestionsAndAnswers()
    {
        return await dbContext.Languages.Include(l => l.Questions)
            .ThenInclude(q => q.Answers).ToListAsync();
    }

    public async Task<Language?> GetLanguageById(Guid id)
    {
        return await dbContext.Languages.Include(l => l.Questions)
            .ThenInclude(q => q.Answers)
            .FirstOrDefaultAsync(l => l.Id == id);
        var language = dbContext.Languages.FirstOrDefaultAsync(language => language.Id == id);

        return await language;
        
    }

    public async Task AddNewLanguage(Language language)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateLanguageDetails(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteLanguage(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Language> GetLanguageByName(string name)
    {
        throw new NotImplementedException();
    }
}