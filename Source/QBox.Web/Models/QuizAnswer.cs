using QBox.Api.DTO;

namespace QBox.Web.Models
{
    public class QuizAnswer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
    }

    public class QuizResultModel
    {
        public QuizResultModel(GameResultDTO result)
        {
            TotalNrQuestions = result.TotalNrQuestions;
            NrCorrectAnswers = result.CorrectNrAnswers;
            Verdict = result.ScoreMessage;
        }

        public int TotalNrQuestions { get; set; }
        public int NrCorrectAnswers { get; set; }
        public string Verdict { get; set; }
    }
}