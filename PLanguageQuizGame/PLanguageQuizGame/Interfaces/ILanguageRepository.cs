using PLanguageQuizGame.Models;

namespace PLanguageQuizGame.Interfaces;

public interface ILanguageRepository
{
    Task<IEnumerable<Language>> GetLanguagesWithQuestionsAndAnswers();

    Task<Language?> GetLanguageById(Guid id);

    Task AddNewLanguage(Language language);

    Task UpdateLanguageDetails(Guid id);
    Task DeleteLanguage(Guid id);

    Task<Language> GetLanguageByName(string name);
}