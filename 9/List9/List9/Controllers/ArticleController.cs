using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using List9.ArticleContext;
using List9.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace List9.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticlesContext _articlesContext;
        // GET: ArticleController
        public ArticleController(IArticlesContext articlesContext)
        {
            _articlesContext = articlesContext;
        }

        public ActionResult Index()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            return View(_articlesContext.GetArticles());
        }

        // GET: ArticleController/Details/5
        public ActionResult Details(int id)
        {
            return View(_articlesContext.GetArticle(id));
        }

        // GET: ArticleController/Create
        public ActionResult Create()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            return View();
        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Article article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _articlesContext.AddArticle(article);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Edit/5
        public ActionResult Edit(int id)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            return View(_articlesContext.GetArticle(id));
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Article article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    article.Id = id;
                    _articlesContext.UpdateArticle(article);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            return View(_articlesContext.GetArticle(id));
        }

        // POST: ArticleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _articlesContext.RemoveArticle(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
