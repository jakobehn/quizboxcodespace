using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Polly;
using QBox.Api.DTO;
using QBoxCore.Api.Models;


namespace QBox.Api.Controllers
{

    [Route("api/category")]
    public class CategoryController : Controller
    {
        public IEnumerable<CategoryDTO> Get()
        {
            var sqlRetryPolicy = Policy
              .Handle<Exception>()
              .WaitAndRetry(new[]
              {
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(5)
              });

            return sqlRetryPolicy.Execute(() => {
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


            });
        }


    }

    
}
