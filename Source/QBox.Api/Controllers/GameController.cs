using System;
using System.Collections.Generic;
using System.Web.Http;
using QBox.Api.DTO;

namespace QBox.Api.Controllers
{
    [RoutePrefix("Game")]
    public class GameController : ApiController
    {

        [HttpPost]
        [Route("{category}")]
        public IEnumerable<QuestionDTO> StartNewGame(string category)
        { 
            //TODO: Generate a new game
            int gameId = 1;
            return new List<QuestionDTO>
            {
                new QuestionDTO(1, gameId, "Some question", category, 1, new List<QuestionChoiceDTO>
                {
                    new QuestionChoiceDTO(1,"Answer 1"),
                    new QuestionChoiceDTO(2,"Answer 2"),
                    new QuestionChoiceDTO(3,"Answer 3"),
                    new QuestionChoiceDTO(4,"Answer 4")
                }),
                new QuestionDTO(1, gameId, "Some question 2", category, 2, new List<QuestionChoiceDTO>
                {
                    new QuestionChoiceDTO(1,"Answer 1"),
                    new QuestionChoiceDTO(2,"Answer 2"),
                    new QuestionChoiceDTO(3,"Answer 3"),
                    new QuestionChoiceDTO(4,"Answer 4")
                })
            };
        }

        [HttpPost]
        [Route("{gameId}/")]
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