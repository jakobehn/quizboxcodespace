using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBox.Api.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CategoryDTO()
        {
        }

        public CategoryDTO(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }

    public class AnswerDTO
    {
        public int QuestionId { get; set; }
        public int SelectedAnswer { get; set; }
    }

    public class GameResultDTO
    {
        public int GameId { get; set; }
        public int TotalNrQuestions { get; set; }
        public int CorrectNrAnswers { get; set; }
        public string ScoreMessage { get; set; }
    }

    public class QuestionDTO
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public string Question { get; set; }

        public string Category { get; set; }
        public int QuestionNr { get; set; }
        public int TotalNrQuestions { get; set; }

        public List<QuestionChoiceDTO> Choices { get; set; }

        public QuestionDTO()
        {
            
        }

        public QuestionDTO(int id, int gameId, string question, string category, int questionNr, int totalNrQuestions, List<QuestionChoiceDTO> choices)
        {
            Id = id;
            GameId = gameId;
            Question = question;
            Category = category;
            QuestionNr = questionNr;
            TotalNrQuestions = totalNrQuestions;
            Choices = choices;
        }
    }

    public class GameDTO
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public class QuestionChoiceDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public QuestionChoiceDTO()
        {
            
        }

        public QuestionChoiceDTO(int id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
