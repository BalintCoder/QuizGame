namespace PLanguageQuizGame.DTOS;

public class AnswerDTO
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}