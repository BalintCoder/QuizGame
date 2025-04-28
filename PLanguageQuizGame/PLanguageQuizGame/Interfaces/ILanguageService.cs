using PLanguageQuizGame.DTOS;
using PLanguageQuizGame.Models;

namespace PLanguageQuizGame.Interfaces;

public interface ILanguageService
{
    Task<IEnumerable<Language>> GetLanguageQuestionsAnswers();

    Task<Language?> LanguageById(Guid id);

    Task AddNewLanguage(LanguageDTO dto);

    Task UpdateLanguage(Guid id, LanguageDTO languageDto);

    Task UpdateQuestion(Guid languageId, Guid questionId, QuestionDTO questionDto);

    Task UpdateAnswer(Guid languageId, Guid questionId, Guid answerId, AnswerDTO answerdto);

    Task RemoveLanguage(Guid id);

    Task<Language?> LanguageByName(string name);
}