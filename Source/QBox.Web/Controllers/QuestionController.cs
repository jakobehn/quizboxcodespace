using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QBox.Api.Client;
using QBox.Web.Models;

namespace QBox.Web.Controllers
{
    [RoutePrefix("Question")]
    public class QuestionController : Controller
    {
        private readonly IQBoxClient apiClient;

        public QuestionController(IQBoxClient apiClient)
        {
            this.apiClient = apiClient;
        }

        [Route("{category}/{questionNr?}")]
        public ActionResult Index(string category, int questionNr=1)
        {
            if (questionNr == 1)
            {
                var question = apiClient.StartGame(category);
            }
            var model = GetNextQuestion(questionNr);
            if (model == null)
                return View("Finished");
            return View(model);
        }

        [HttpPost]
        [Route("PostAnswer")]
        public ActionResult PostAnswer(QuizQuestionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            //TODO: Store answer on backend

            return RedirectToAction("Index", new {category = model.Category, questionNr = model.QuestionNr + 1});
        }

        [HttpPost]
        [Route("PostScore")]
        public ActionResult PostScore()
        {
            return View();
        }

        private QuizQuestionViewModel GetNextQuestion(int questionNr)
        {

            var questions = new List<QuizQuestionViewModel>
            {
                new QuizQuestionViewModel()
                {
                    Id = 1,
                    Category = "Sports",
                    Question = "Some question",
                    Answers = new List<QuizAnswer>
                    {
                        new QuizAnswer
                        {
                            Id = 1,
                            AnswerText = "Answer 1"
                        },
                        new QuizAnswer
                        {
                            Id = 2,
                            AnswerText = "Answer 2"
                        },
                        new QuizAnswer
                        {
                            Id = 3,
                            AnswerText = "Answer 3"
                        },
                        new QuizAnswer
                        {
                            Id = 4,
                            AnswerText = "Answer 4"
                        }
                    },
                    QuestionNr = 1,
                    QuestionsTotalNr = 5
                },
                new QuizQuestionViewModel()
                {
                    Id = 2,
                    Category = "Sports",
                    Question = "Some question 2",
                    Answers = new List<QuizAnswer>
                    {
                        new QuizAnswer
                        {
                            Id = 1,
                            AnswerText = "Answer 1"
                        },
                        new QuizAnswer
                        {
                            Id = 2,
                            AnswerText = "Answer 2"
                        },
                        new QuizAnswer
                        {
                            Id = 3,
                            AnswerText = "Answer 3"
                        },
                        new QuizAnswer
                        {
                            Id = 4,
                            AnswerText = "Answer 4"
                        }
                    },
                    QuestionNr = 2,
                    QuestionsTotalNr = 5
                },
                new QuizQuestionViewModel()
                {
                    Id = 3,
                    Category = "Sports",
                    Question = "Some question 3",
                    Answers = new List<QuizAnswer>
                    {
                        new QuizAnswer
                        {
                            Id = 1,
                            AnswerText = "Answer 1"
                        },
                        new QuizAnswer
                        {
                            Id = 2,
                            AnswerText = "Answer 2"
                        },
                        new QuizAnswer
                        {
                            Id = 3,
                            AnswerText = "Answer 3"
                        },
                        new QuizAnswer
                        {
                            Id = 4,
                            AnswerText = "Answer 4"
                        }
                    },
                    QuestionNr = 3,
                    QuestionsTotalNr = 5
                },
                new QuizQuestionViewModel()
                {
                    Id = 4,
                    Category = "Sports",
                    Question = "Some question 4",
                    Answers = new List<QuizAnswer>
                    {
                        new QuizAnswer
                        {
                            Id = 1,
                            AnswerText = "Answer 1"
                        },
                        new QuizAnswer
                        {
                            Id = 2,
                            AnswerText = "Answer 2"
                        },
                        new QuizAnswer
                        {
                            Id = 3,
                            AnswerText = "Answer 3"
                        },
                        new QuizAnswer
                        {
                            Id = 4,
                            AnswerText = "Answer 4"
                        }
                    },
                    QuestionNr = 4,
                    QuestionsTotalNr = 5
                },
                new QuizQuestionViewModel()
                {
                    Id = 5,
                    Category = "Sports",
                    Question = "Some question 5",
                    Answers = new List<QuizAnswer>
                    {
                        new QuizAnswer
                        {
                            Id = 1,
                            AnswerText = "Answer 1"
                        },
                        new QuizAnswer
                        {
                            Id = 2,
                            AnswerText = "Answer 2"
                        },
                        new QuizAnswer
                        {
                            Id = 3,
                            AnswerText = "Answer 3"
                        },
                        new QuizAnswer
                        {
                            Id = 4,
                            AnswerText = "Answer 4"
                        }
                    },
                    QuestionNr = 5,
                    QuestionsTotalNr = 5
                }
            };

            return questions.FirstOrDefault(q => q.QuestionNr == questionNr);
        }

    }
}