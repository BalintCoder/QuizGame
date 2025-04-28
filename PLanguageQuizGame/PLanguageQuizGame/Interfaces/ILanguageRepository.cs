using PLanguageQuizGame.DTOS;
using PLanguageQuizGame.Models;

namespace PLanguageQuizGame.Interfaces;

public interface ILanguageRepository
{
    Task<IEnumerable<Language>> GetLanguagesWithQuestionsAndAnswers();
    Task<Language?> GetLanguageById(Guid id);
    Task<Language?> GetLanguageByName(string name);
        
    Task AddNewLanguage(LanguageDTO languageDto);
    Task UpdateLanguageDetails(Guid id, LanguageDTO languageDto);
    Task UpdateQuestionDetails(Guid languageId, Guid questionId, QuestionDTO questionDto);
    Task UpdateAnswerDetails(Guid languageId, Guid questionId, Guid answerId, AnswerDTO answerDto);
        
    Task DeleteLanguage(Guid id);
}