using PLanguageQuizGame.Models;

namespace PLanguageQuizGame.DTOS;

public class LanguageDTO
{
    public string Name { get; set; }

    public ICollection<QuestionDTO> Questions { get; set; } = new List<QuestionDTO>();
}