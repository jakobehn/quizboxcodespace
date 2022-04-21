using System.Collections.Generic;

namespace QBoxCore.Web.Models
{
    public class QuizCategoriesViewModel
    {
        public List<QuizCategoryViewModel> Categories { get; set; }
        public bool ShowRandomCategory { get; set; }

    }
}