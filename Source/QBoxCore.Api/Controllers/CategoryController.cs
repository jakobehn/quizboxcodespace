using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QBox.Api.DTO;
using QBoxCore.Api.Models;


namespace QBox.Api.Controllers
{

    [Route("api/category")]
    public class CategoryController : Controller
    {
        public IEnumerable<CategoryDTO> Get()
        {
            using (var ctx = new QuizBoxContext())
            {
                return ctx.Category.Select(
                    c => new CategoryDTO()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description
                    }).ToList();
            }
        }


    }

    
}
