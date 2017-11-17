using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QBox.Api.Client;
using QBox.Logging;
using QBox.Web.Models;

namespace QBox.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IQBoxClient apiClient;

        public CategoryController(IQBoxClient apiClient)
        {
            this.apiClient = apiClient;
        }


        public ActionResult Index()
        {
            var allCategories = apiClient.GetCategories().Result;
            var model = new QuizCategoriesViewModel
            {
                Categories = allCategories.Select(
                    c => new QuizCategoryViewModel() { Id = c.Id, Name = c.Name, Description = c.Description }).ToList()
            };
            model.ShowRandomCategory = true;

            return View(model);

        }

        [HttpPost]
        public ActionResult Start(IFormCollection form)
        {
            if (!form.Any())
            {
                return RedirectToAction("Index");
            }

            string selectedCategory = Convert.ToString(form.First().Value);
            QBox.Logging.Logger.Event(selectedCategory);

            return RedirectToAction("Index", "Question", new {category=selectedCategory});
        }

        [HttpPost]
        public async Task<ActionResult> Random()
        {
            var allCategories = await apiClient.GetCategories();
            var selectedCategory = allCategories[new Random().Next(0, allCategories.Count - 1)].Name;
            Logger.Event("randomCategory");
            return RedirectToAction("Index", "Question", new { category = selectedCategory });
        }

    }

}