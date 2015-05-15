using System.Collections.Generic;
using System.Web.Http;
using QBox.Api.DTO;
using QBox.Api.Models;

namespace QBox.Api.Controllers
{
    [RoutePrefix("Category")]
    public class CategoryController : ApiController
    {
        public IEnumerable<CategoryDTO> Get()
        {
            return new List<CategoryDTO>
            {
                new CategoryDTO(1, "Sports", "Questions about sports"),
                new CategoryDTO(2, "Nature", "Questions about nature"),
                new CategoryDTO(3, "Art", "Questions about art")
            };
        }
    }
}
