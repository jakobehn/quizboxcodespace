using System.Collections.Generic;
using System.Web.Http;
using QBox.Api.DTO;

namespace QBox.Api.Controllers
{
    [RoutePrefix("Game")]
    public class GameController : ApiController
    {
        public IEnumerable<QuestionDTO> Get(int id)
        { 
            //TODO: Get category from id
            string category = "Sports";

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
                })
            };
        }
    }
}