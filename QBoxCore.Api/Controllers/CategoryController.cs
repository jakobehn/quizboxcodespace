using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QBoxCore.Api.DTO;
using QBoxCore.Api.Migrations;
using QBoxCore.Api.Models;

namespace QBoxCore.Api.Controllers
{

    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private readonly DbInitializer initializer;

        public CategoryController(DbInitializer initializer)
        {
            this.initializer = initializer;

        }
        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            using (var context = new QuizBoxContext())
            {
                context.Database.Migrate();
            }

            initializer.Seed();

            IEnumerable<CategoryDTO> categories = new List<CategoryDTO>();

            using (var ctx = new QuizBoxContext())
            {
                categories = ctx.Category.Select(
                    c => new CategoryDTO()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description
                    }).ToList();
                return categories;
            }
        }


    }
    
}
