using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QBoxCore.Api.DTO;
using QBoxCore.Api;
using QBoxCore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace QBoxCore.Api.Controllers
{
    [ApiController]
    [Route("highscore")]
    public class HighscoreController : ControllerBase
    {
        public IEnumerable<ScoreDTO> Get()
        {
            using (var ctx = new QuizBoxContext())
            {
                return ctx.Highscore.Include(c => c.Category).Select(
                    c => new ScoreDTO()
                    {
                        Id = c.Id,
                        User = c.UserId,
                        CategoryName = c.Category.Name,
                        CategoryId = c.Category.Id,
                        ScorePercent = c.ScorePercent,
                        Duration = c.TimeElapsedSeconds,
                        Age = c.Age
                    }).OrderByDescending(c => c.ScorePercent).ThenByDescending(c => c.Id).Take(10).ToList();
            }
        }

        [HttpPost]
        [Route("{gameid}/{user}/{age:int?}")]
        public void Post(int gameId, string user, int? age = null)
        {
            using (var ctx = new QuizBoxContext())
            {
                var game = ctx.Game
                    .Include(g => g.Category)
                    .Include(g => g.GameQuestion)
                        .ThenInclude(g => g.Answer).First(g => g.Id == gameId);
                int totalNrQuestions = game.GameQuestion.Count();
                int nrCorrectAnswers = game.GameQuestion.Count(q => q.Answer.IsCorrect);
                var scorePercent = ((double)nrCorrectAnswers / (double)totalNrQuestions) * 100;

                ctx.Highscore.Add(new Highscore()
                {
                    Category = game.Category,
                    ScorePercent = scorePercent,
                    EndTime = DateTime.Now,
                    TimeElapsedSeconds = (DateTime.Now - game.Start).Seconds,
                    UserId = user,
                    Age = age
                }
                    );
                ctx.SaveChanges();
            }
        }

    }
}