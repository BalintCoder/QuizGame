using Microsoft.EntityFrameworkCore;
using PLanguageQuizGame.Data;
using PLanguageQuizGame.DTOS;
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
    }

    public async Task AddNewLanguage(LanguageDTO languageDto)
    {

        if (languageDto == null)
        {
            throw new ArgumentNullException(nameof(languageDto));
        }

        var language = new Language
        {
            Name = languageDto.Name,
            Questions = languageDto.Questions?.Select(q => new Question
            {
                Text = q.Text,
                Answers = q.Answers.Select(a => new Answer
                {
                    Text = a.Text,
                    IsCorrect = a.IsCorrect
                }).ToList() ?? new List<Answer>()
            }).ToList() ?? new List<Question>()
        };

        await dbContext.Languages.AddAsync(language);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateLanguageDetails(Guid id, LanguageDTO languageDto)
    {
        var language = await dbContext.Languages.FirstOrDefaultAsync(l => l.Id == id);

        if (language == null)
        {
            throw new Exception("Cannot find this language");
        }


        language.Name = languageDto.Name;

        await dbContext.SaveChangesAsync();

    }
    
    public async Task UpdateQuestionDetails(Guid languageId, Guid questionId, QuestionDTO questionDto)
    {

        var language = await dbContext.Languages.FirstOrDefaultAsync(l => l.Id == languageId);

        var question = await dbContext.Questions.FirstOrDefaultAsync(q => q.Id == questionId);

        if (language == null || question == null)
        {
            throw new Exception("Language or Question not found.");
        }

        if (question.LanguageId != languageId)
        {
            throw new Exception("This question does not belong to the specified language.");
        }

        question.Text = questionDto.Text;
      await  dbContext.SaveChangesAsync();

    }
    
    
    public async Task UpdateAnswerDetails(Guid languageId, Guid questionId, Guid answerId, AnswerDTO answerdto)
    {

        var language = await dbContext.Languages.FirstOrDefaultAsync(l => l.Id == languageId);

        var question = await dbContext.Questions.FirstOrDefaultAsync(q => q.Id == questionId);

        var answer = await dbContext.Answers.FirstOrDefaultAsync(a => a.Id == answerId);

        if (language == null || question == null || answer == null)
        {
            throw new Exception("Language or Question or Answer not found.");
        }

        if (question.LanguageId != languageId)
        {
            throw new Exception("This question does not belong to the specified language.");
        }
        
        if (answer.QuestionId != questionId)
        {
            throw new Exception("This anwer does not belong to the specified question.");
        }

        answer.Text = answerdto.Text;
        answer.IsCorrect = answerdto.IsCorrect;
        await  dbContext.SaveChangesAsync();

    }

    public async Task DeleteLanguage(Guid id)
    {
        var language = await dbContext.Languages.FirstOrDefaultAsync(l => l.Id == id);

        if (language == null)
            throw new Exception("Language not found");
        
        dbContext.Remove(language);

        await dbContext.SaveChangesAsync();

    }

    public async Task<Language?> GetLanguageByName(string name)
    {
        return await dbContext.Languages.Include(l => l.Questions)
            .ThenInclude(q => q.Answers)
            .FirstOrDefaultAsync(l => l.Name == name);
    }
}