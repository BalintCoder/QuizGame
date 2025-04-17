namespace PLanguageQuizGame.Models;

public class Answer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Text { get; set; } = null!;
    
    public bool IsCorrect { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; } = null!;
}