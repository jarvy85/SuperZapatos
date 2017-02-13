using Modelos;
using Modelos.ViewModel;
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
            var _cliente = new Client.ApiClient();
            var _resultado = _cliente.ExecuteGet<articlesViewModel>("services", "articles");
            return View(_resultado);
        }

        public ActionResult Save(articles _entidad)
        {
            if (ModelState.IsValid)
            {
            }
            var _cliente = new Client.ApiClient();
            var _resultado = _cliente.ExecutePost<articles>("services/articles/postarticle", _entidad);
            return RedirectToAction("Index");
        }

        public ActionResult SaveCreate(articles _entidad)
        {
            if (ModelState.IsValid)
            {
            }
            var _cliente = new Client.ApiClient();
            var _resultado = _cliente.ExecutePut<articles>("services/articles/putarticle", _entidad);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var _cliente = new Client.ApiClient();
            var _resultado = _cliente.ExecuteGet<articles>("services", "articles", id.ToString());
            return View(_resultado);
        }

        public ActionResult DoDelete(articles _entity)
        {
            var _cliente = new Client.ApiClient();
            var _resultado = _cliente.ExecuteDelete("services/articles/deletearticle", _entity.id);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}