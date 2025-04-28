namespace PLanguageQuizGame.Models;

public class Question
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Text { get; set; } = null!;
    
    public Guid LanguageId { get; set; } = Guid.NewGuid();

    public Language Language { get; set; } = null!;
    
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    
    

}