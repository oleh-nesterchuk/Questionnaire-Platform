using Microsoft.Extensions.DependencyInjection;
using Questionnaire.Core.Entities;
using Questionnaire.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Questionnaire.Dal
{
    public static class SeedData
    {
        private static QuestionnaireDbContext _context;
        private static IServiceScope _scope;

        public static void EnsurePopulated(IServiceProvider services)
        {
            InitializeContext(services);
            EnsureQuestionnairesAdded();
            DestroyContext();
        }

        private static void InitializeContext(IServiceProvider services)
        {
            _scope = services.CreateScope();
            _context = _scope.ServiceProvider.GetRequiredService<QuestionnaireDbContext>();
        }

        private static void EnsureQuestionnairesAdded()
        {
            if (_context.Questionnaires.Count() == 0)
            {
                _context.Questionnaires.AddRange(
                    new Core.Entities.Questionnaire()
                    {
                        CreationTime = DateTime.UtcNow,
                        CreatorId = 1,
                        IsAnonymous = true,
                        Title = "Conspiracy theories",
                        Questions = new List<Question>()
                        {
                        new Question()
                        {
                            IsRequired = true, Text = "Is Mark Zuckerberg a lizard?",
                            Type = QuestionType.SingleChoice,
                            Answers = new List<Answer>()
                            {
                                new Answer() { Text = "Yes" },
                                new Answer() { Text = "Definitely" },
                                new Answer() { Text = "Nope" },
                            }
                        },
                        new Question()
                        {
                            IsRequired = false, Text = "Why does Bill Gates plan to inject 5G microchips in our heads?",
                            Type = QuestionType.MultipleChoice,
                            Answers = new List<Answer>()
                            {
                                new Answer() { Text = "To destroy humanity and sell our planet to aliens" },
                                new Answer() { Text = "To gift everyone free access to the Internet" },
                                new Answer() { Text = "He works for the American government" },
                                new Answer() { Text = "He wants to become the leader of World Jewish Congress" }
                            }
                        }
                        }
                    },
                    new Core.Entities.Questionnaire()
                    {
                        CreationTime = DateTime.UtcNow.AddDays(-2),
                        CreatorId = 1,
                        IsAnonymous = false,
                        Title = "Memes",
                        Questions = new List<Question>()
                        {
                        new Question()
                        {
                            IsRequired = true,
                            Type = QuestionType.OpenEnded,
                            Text = "Who is Doge for you?",
                            Answers = new List<Answer>()
                            {
                                new Answer()
                                {
                                    CanUserWrite = true
                                }
                            }
                        },
                        new Question()
                        {
                            IsRequired = true,
                            Type = QuestionType.SingleChoice,
                            Text = "Doge or Cheems?",
                            Answers = new List<Answer>()
                            {
                                new Answer()
                                {
                                    Text = "Doge"
                                },
                                new Answer()
                                {
                                    Text = "Cheems"
                                }
                            }
                        }
                        }
                    });
                _context.SaveChanges();
            }
        }

        private static void DestroyContext()
        {
            _scope.Dispose();
        }
    }
}
