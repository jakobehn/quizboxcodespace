using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QBox.Api.Client;
using QBox.Api.DTO;
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
                var questions = apiClient.StartGame(category).Result;
                //Temp until databaseis available
                Session["questions"] = questions;
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
            var game = Session["questions"] as GameDTO;

            var model = new List<QuizQuestionViewModel>();
            foreach( var q in game.Questions)
            {
                var questionModel = new QuizQuestionViewModel()
                {
                    Id = q.Id,
                    Category = q.Category,
                    Question = q.Question,
                    QuestionNr = q.QuestionNr,
                    QuestionsTotalNr = game.Questions.Count()
                };
                questionModel.Answers = new List<QuizAnswer>();
                foreach (var a in q.Choices)
                {
                    questionModel.Answers.Add(
                        new QuizAnswer()
                        {
                            Id = a.Id,
                            AnswerText = a.Text
                        });
                }
                model.Add(questionModel);
            }

            return model.FirstOrDefault(q => q.QuestionNr == questionNr);
        }

    }
}