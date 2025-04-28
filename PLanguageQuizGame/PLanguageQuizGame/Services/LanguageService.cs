using System.Collections;
using PLanguageQuizGame.DTOS;
using PLanguageQuizGame.Interfaces;
using PLanguageQuizGame.Models;
using PLanguageQuizGame.Repositories;

namespace PLanguageQuizGame.Services;

public class LanguageService : ILanguageService
{
    private readonly ILanguageRepository _languageRepository;

    public LanguageService(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public async Task<IEnumerable<Language>> GetLanguageQuestionsAnswers()
    {
        return await _languageRepository.GetLanguagesWithQuestionsAndAnswers();
    }

    public async Task<Language?> LanguageById(Guid id)
    {
        return await _languageRepository.GetLanguageById(id);
    }

    public async Task AddNewLanguage(LanguageDTO dto)
    {
        await _languageRepository.AddNewLanguage(dto);
    }

    public async Task UpdateLanguage(Guid id, LanguageDTO languageDto)
    {
        await _languageRepository.UpdateLanguageDetails(id, languageDto);
    }

    public async Task UpdateQuestion(Guid languageId, Guid questionId, QuestionDTO questionDto)
    {
        await _languageRepository.UpdateQuestionDetails(languageId, questionId, questionDto);
    }

    public async Task UpdateAnswer(Guid languageId, Guid questionId, Guid answerId, AnswerDTO answerdto)
    {
        await _languageRepository.UpdateAnswerDetails(languageId, questionId, answerId, answerdto);
    }

    public async Task RemoveLanguage(Guid id)
    {
        await _languageRepository.DeleteLanguage(id);
    }

    public async Task<Language?> LanguageByName(string name)
    {
        return await _languageRepository.GetLanguageByName(name);
    }
}