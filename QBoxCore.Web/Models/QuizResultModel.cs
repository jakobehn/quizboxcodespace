using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using QBoxCore.Api.DTO;

namespace QBoxCore.Web.Models
{
    public class QuizResultModel
    {
        public QuizResultModel()
        {
        }

        public QuizResultModel(GameResultDTO result)
        {
            TotalNrQuestions = result.TotalNrQuestions;
            NrCorrectAnswers = result.CorrectNrAnswers;
            Verdict = result.ScoreMessage;
            GameId = result.GameId;
        }

        public int TotalNrQuestions { get; set; }
        public int NrCorrectAnswers { get; set; }
        public string Verdict { get; set; }
        [Required]
        public string Name { get; set; }

        public int GameId { get; set; }
    }
}