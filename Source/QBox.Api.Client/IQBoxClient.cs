using System.Collections.Generic;
using System.Threading.Tasks;
using QBox.Api.DTO;

namespace QBox.Api.Client
{
    public interface IQBoxClient
    {
        Task<List<CategoryDTO>> GetCategories();
        Task<GameDTO> StartGame(int categoryId, int nrQuestions);
        Task<GameResultDTO> PostResult(int gameId, IEnumerable<AnswerDTO> answers);
        Task<QuestionDTO> GetQuestion(int gameId, int questionNr);
        Task SaveAnswer(int gameId, int questionNr, int selectedAnswer);
    }
}