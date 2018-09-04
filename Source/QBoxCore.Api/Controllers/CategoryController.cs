using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polly;
using QBox.Api.DTO;
using QBox.Api.Migrations;
using QBoxCore.Api.Models;


namespace QBox.Api.Controllers
{

    [Route("api/category")]
    public class CategoryController : Controller
    {
        private readonly DbInitializer initializer;

        public CategoryController(DbInitializer initializer)
        {
            this.initializer = initializer;

        }
        public IEnumerable<CategoryDTO> Get()
        {
            var sqlRetryPolicy = Policy
              .Handle<Exception>()
              .WaitAndRetry(new[]
              {
                TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(15)
              }, (exception, timeSpan) => {
                  try
                  { 
                  using (var context = new QuizBoxContext())
                  {
                      context.Database.Migrate();
                  }

                  initializer.Seed();
                  }
                  catch( Exception ex)
                  {
                      //TODO: Log
                  }
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
