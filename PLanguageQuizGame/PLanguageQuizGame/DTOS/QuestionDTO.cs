using PLanguageQuizGame.Models;

namespace PLanguageQuizGame.DTOS;

public class QuestionDTO
{
    public Guid Id { get; set; }
    public string Text { get; set; } = null!;
    public ICollection<AnswerDTO> Answers { get; set; } = new List<AnswerDTO>();
}