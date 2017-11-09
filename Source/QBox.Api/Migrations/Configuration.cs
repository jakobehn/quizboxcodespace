using System.Collections.Generic;
using QBox.Api.Database;

namespace QBox.Api.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QBox.Api.Database.QuizBoxContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(QBox.Api.Database.QuizBoxContext context)
        {
            if (context.Category.Any())
                return;

            context.Category.AddRange(
                new List<Category>
                {
                    new Category()
                    {
                        Id = 1,
                        Name = "Sports",
                        Question = new List<Question>()
                        {
                            new Question()
                            {
                                Id = 1,
                                Text = "Which country won world cup in soccer 2014",
                                Answer = new List<Answer>()
                                {
                                    new Answer()
                                    {
                                        Text = "Brazil",
                                        IsCorrect = false
                                    },
                                    new Answer()
                                    {
                                        Text = "Germany",
                                        IsCorrect = true
                                    },
                                    new Answer()
                                    {
                                        Text = "Sweden",
                                        IsCorrect = false
                                    },
                                    new Answer()
                                    {
                                        Text = "Spain",
                                        IsCorrect = false
                                    }
                                }
                            }
                        }
                    },
                    new Category()
                    {
                        Id = 2,
                        Name = "Food"
                    },
                    new Category()
                    {
                        Id = 4,
                        Name = "Entertainment"
                    },
                    new Category()
                    {
                        Id = 5,
                        Name = "Music"
                    },
                    new Category()
                    {
                        Id = 6,
                        Name = "American trivia",                        
                    },
                    new Category()
                    {
                        Id = 7,
                        Name = "Geek",
                    },
                });

            context.SaveChanges();

        }
    }
}
