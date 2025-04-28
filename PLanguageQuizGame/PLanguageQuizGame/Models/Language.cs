namespace PLanguageQuizGame.Models;

public class Language
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Name { get; set; }

    public ICollection<Question> Questions { get; set; } = new List<Question>();
}