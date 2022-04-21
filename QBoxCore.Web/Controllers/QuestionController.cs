using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QBoxCore.Api.Client;
using QBoxCore.Logging;
using QBoxCore.Web.Models;

namespace QBoxCore.Web.Controllers
{
    [Route("Question")]
    public class QuestionController : Controller
    {
        private readonly IQBoxClient apiClient;
        private readonly ILogger logger;

        public QuestionController(IQBoxClient apiClient, ILogger logger)
        {
            this.apiClient = apiClient;
            this.logger = logger;
        }

        [Route("{category}/{gameId?}/{questionNr?}")]
        public ActionResult Index(string category, int? gameId = null, int questionNr=1 )
        {
            if (questionNr == 1)
            {
                var game = apiClient.StartGame(category,5).Result;
                gameId = game.Id;
            }

            if( gameId.HasValue)
            { 
                var q = apiClient.GetQuestion(gameId.Value, questionNr).Result;
                if (q != null)
                {
                    var questionModel = new QuizQuestionViewModel()
                    {
                        Id = q.Id,
                        Category = q.Category,
                        Question = q.Question,
                        QuestionNr = q.QuestionNr,
                        QuestionsTotalNr = q.TotalNrQuestions,
                        GameId = gameId.Value 
                    };
                    questionModel.Answers = new List<QuizAnswerModel>();
                    foreach (var a in q.Choices)
                    {
                        questionModel.Answers.Add(
                            new QuizAnswerModel()
                            {
                                Id = a.Id,
                                AnswerText = a.Text
                            });
                    }

                    return View(questionModel);
                }
            }

            var result = this.apiClient.FinishGame(gameId.Value).Result;

            return View("Finished", new QuizResultModel(result));
        }

        [HttpPost]
        [Route("PostAnswer")]
        public async Task<ActionResult> PostAnswer(QuizQuestionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            await apiClient.SaveAnswer(model.GameId, model.QuestionNr, model.SelectedAnswer);

            return RedirectToAction("Index", new {category = model.Category, questionNr = model.QuestionNr + 1, gameId = model.GameId});
        }

        [HttpPost]
        [Route("PostScore")]
        public async Task<ActionResult> PostScore(QuizResultModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            logger.Event("PostHighscore");

            await apiClient.PostHighScore(model.GameId, model.Name);
            return RedirectToAction("Index", "Highscore");
        }
    }
}