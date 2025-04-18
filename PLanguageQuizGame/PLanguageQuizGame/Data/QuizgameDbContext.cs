using Microsoft.EntityFrameworkCore;
using PLanguageQuizGame.Models;

namespace PLanguageQuizGame.Data;

public class QuizgameDbContext : DbContext
{
    public QuizgameDbContext(DbContextOptions<QuizgameDbContext> options)
    : base(options)
    {
    }
    public DbSet<Language> Languages { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<Answer> Answers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Question>()
            .HasMany(q => q.Answers)
            .WithOne(a => a.Question)
            .HasForeignKey(a => a.QuestionId);

        modelBuilder.Entity<Language>()
            .HasMany(l => l.Questions)
            .WithOne(q => q.Language)
            .HasForeignKey(q => q.LanguageId);

    }
}