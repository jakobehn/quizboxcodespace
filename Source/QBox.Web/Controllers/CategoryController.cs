using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using LaunchDarkly.Client;
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
            try
            {
                var allCategories = apiClient.GetCategories().Result;
                var model = new QuizCategoriesViewModel
                {
                    Categories = allCategories.Select(
                        c => new QuizCategoryViewModel() { Id = c.Id, Name = c.Name, Description = c.Description }).ToList()
                };
                User user = LaunchDarkly.Client.User.WithKey("jakob.ehn");
                LdClient ldClient = new LdClient("sdk-8293e169-ff75-4bb2-909e-2e34f70b550f");
                if (ldClient.BoolVariation("random-category", user))
                {
                    model.ShowRandomCategory = true;
                }
                return View(model);
            }
            catch( Exception ex)
            {
                Response.Write(ex.ToString());
                Response.End();
            }
            return null;
        }

        [HttpPost]
        public ActionResult Start(FormCollection form)
        {
            if (form.Count != 1)
            {
                return RedirectToAction("Index");
            }

            string selectedCategory = Convert.ToString(form[0]);
            Logger.Event(selectedCategory);

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