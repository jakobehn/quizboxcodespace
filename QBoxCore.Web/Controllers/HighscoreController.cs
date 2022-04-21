using Microsoft.AspNetCore.Mvc;
using QBoxCore.Api.Client;
using QBoxCore.Web.Models;

namespace QBoxCore.Web.Controllers
{
    public class HighscoreController : Controller
    {
        private readonly IQBoxClient api;

        public HighscoreController(IQBoxClient api)
        {
            this.api = api;
        }

        // GET: Highscore
        public ActionResult Index()
        {
            var highscore = api.GetHighscore().Result;
            var model = new HighScoreModel(highscore);
            return View(model);
        }
    }
}