using Culture_kg.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Culture_kg.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        //ApplicationContext db;

        //public HomeController(ApplicationContext context)
        //{
        //    db = context;
        //}
        public IActionResult Index()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageIndex"));
        }
        public IActionResult Contacts()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageContacts"));
        }

        //[HttpGet]
        //public async Task<IActionResult> GetArticle(int? id)
        //{
        //    if (id != null)
        //    {
        //        Article article = await db.Articles.FirstOrDefaultAsync(p => p.ArticleID == id);
        //        if (User != null)
        //            return View(article);
        //    }
        //    return NotFound();
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateArticle(Article article)
        //{
        //    db.Articles.Add(article);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //public IActionResult CreateArticle()
        //{
        //    return View();
        //}



        //public IActionResult Edit(int? id)
        //{
        //    if (id == null) return RedirectToAction("Index");
        //    ViewBag.ArticleId;
        //    return View();
        //}
        //public IActionResult Edit(Article article)
        //{
        //    db.Articles.

        //  }
    }
}
