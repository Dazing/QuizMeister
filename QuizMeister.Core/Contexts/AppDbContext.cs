using Microsoft.EntityFrameworkCore;
using QuizMeister.Core.Models.DataModels;
using System;

namespace QuizMeister.Core.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuizSession> QuizSessions { get; set; }
        public DbSet<QuizAnswer> QuizAnswers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .HasKey(_ => _.Id);

            modelBuilder.Entity<Question>()
                .HasMany(_ => _.Answers)
                .WithOne(_ => _.Question)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<QuizSession>()
                .HasMany(_ => _.QuizAnswers)
                .WithOne(_ => _.QuizSession)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<QuizAnswer>()
                .HasKey(_ => new { _.QuizSessionId, _.QuestionId });

            modelBuilder.Entity<QuizAnswer>()
                .HasOne(_ => _.Question);
        }
    }
}
