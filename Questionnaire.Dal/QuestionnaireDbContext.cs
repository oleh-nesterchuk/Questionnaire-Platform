using Microsoft.EntityFrameworkCore;
using Questionnaire.Core.Entities;
using Questionnaire.Core.Enums;
using System;

namespace Questionnaire.Dal
{
    public class QuestionnaireDbContext : DbContext
    {
        public QuestionnaireDbContext(DbContextOptions<QuestionnaireDbContext> options) : base(options) { }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<CompletedAnswer> CompletedAnswers { get; set; }
        public DbSet<CompletedQuestionnaire> CompletedQuestionnaires { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Core.Entities.Questionnaire> Questionnaires { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("my connection string");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Answer>(answer =>
            {
                answer.Property(a => a.Text)
                    .HasMaxLength(400);
            });

            builder.Entity<Question>(question =>
            {
                question.Property(q => q.Text)
                    .HasMaxLength(400);

                question.Property(q => q.Type)
                    .HasConversion<string>()
                    .HasMaxLength(50);
            });

            builder.Entity<Core.Entities.Questionnaire>(questionnaire =>
            {
                questionnaire.Property(q => q.Title)
                    .HasMaxLength(200);
            });
        }
    }
}
