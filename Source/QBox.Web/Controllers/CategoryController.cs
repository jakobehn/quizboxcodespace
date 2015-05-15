using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QBox.Api.Client;
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
            try
            {
                var allCategories = apiClient.GetCategories().Result;
                var model = new QuizCategoriesViewModel
                {
                    Categories = allCategories.Select(
                        c => new QuizCategoryViewModel() {Id = c.Id, Name = c.Name, Description = c.Description}).ToList()
                };
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Start(FormCollection form)
        {
            if (form.Count != 1)
            {
                return RedirectToAction("Index");
            }

            string selectedCategory = Convert.ToString(form[0]);

            //Create game
            return RedirectToAction("Index", "Question", new {category=selectedCategory});
        }

    }

}