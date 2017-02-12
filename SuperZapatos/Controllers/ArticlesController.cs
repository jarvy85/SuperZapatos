using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperZapatos.Controllers
{
    public class ArticlesController : Controller
    {
        public ActionResult Index()
        {
            return View(Models.ArticleModels.getArticles());
        }
    }
}