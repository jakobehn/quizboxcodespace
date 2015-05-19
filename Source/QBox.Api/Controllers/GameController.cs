using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using QBox.Api.Database;
using QBox.Api.DTO;

namespace QBox.Api.Controllers
{
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {

        [HttpPost]
        [Route("answer/{gameId}/{questionNr}/{selectedAnswer}")]
        public void SaveAnswer(int gameId, int questionNr, int selectedAnswer)
        {
            using (var ctx = new QuizBoxContext())
            {
                var game = ctx.Game.First(g => g.Id == gameId);
                var question = game.GameQuestion.First(q => q.Order == questionNr);
                question.Answer = ctx.Answer.First(a => a.Id == selectedAnswer);
                ctx.SaveChanges();
            }
        }

        [HttpPost]
        [Route("start/{categoryid}/{nrquestions}")]
        public GameDTO StartNewGame(int categoryId, int nrQuestions)
        {
            int gameId;
            using (var ctx = new QuizBoxContext())
            {
                var selectedCategory = ctx.Category.FirstOrDefault(c => c.Id == categoryId);
                var newGame = new Game()
                {
                    Category = selectedCategory,
                    Start = DateTime.Now,
                    UserId = "1234567890",
                };

                var questionsInGame = ctx.Question.Where(q => q.Category.Id == categoryId).Take(nrQuestions).ToList();
                newGame.GameQuestion = new List<GameQuestion>();
                for (int i = 1; i <= questionsInGame.Count(); i++)
                {
                    newGame.GameQuestion.Add(
                        new GameQuestion()
                        {
                            Game = newGame,
                            Question = questionsInGame[i-1],
                            Order = i
                        });
                }
                ctx.Game.Add(newGame);
                ctx.SaveChanges();
                gameId = newGame.Id;
            }

            using (var ctx = new QuizBoxContext())
            {
                var game = ctx.Game.First(g => g.Id == gameId);
                return new GameDTO
                {
                    Id = game.Id,
                    Start = game.Start
                };
            }
        }

        [HttpGet]
        [Route("{gameid}/{questionNr}")]
        public QuestionDTO GetQuestion(int gameId, int questionNr)
        {
            using (var ctx = new QuizBoxContext())
            {
                var game = ctx.Game.FirstOrDefault(g => g.Id == gameId);
                var question = game.GameQuestion.FirstOrDefault(q => q.Order == questionNr);
                if (question == null)
                    return null;

                return new QuestionDTO(question.Id, gameId, question.Question.Text, game.Category.Name, questionNr,
                    game.GameQuestion.Count(),
                    question.Question.Answer.Select(
                        a => new QuestionChoiceDTO(a.Id, a.Text)).ToList());
            }
        }

        [HttpPost]
        [Route("{gameId}")]
        public GameResultDTO PostScore(int gameId, [FromBody]List<AnswerDTO> answers)
        {
            //TODO: Validate answers
            var result = new GameResultDTO()
            {
                GameId = gameId,
                TotalNrQuestions = 5,
                CorrectNrAnswers = new Random().Next(0,5)
            };
            result.ScoreMessage = GetScoreMessage(result.CorrectNrAnswers);
            return result;
        }

        private string GetScoreMessage(int correctNrAnswers)
        {
            switch (correctNrAnswers)
            {
                case 0:
                    return "Boy, you suck";
                case 1:
                    return "That is really bad";
                case 2:
                    return "Pretty lousy, I'd say";
                case 3:
                    return "Not too shabby";
                case 4:
                    return "Wow, not bad!";
                case 5:
                    return "Nailed it!";
                default:
                    return "Unknown result";
            }
        }
    }
}