using Class_Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class_Blog.Controllers
{
    public class HomeController : Controller
    {
        int limit = 6;
        Context db = new Context();
        public ActionResult Index()
        {
            List<NewsClassModels> news = db.NewsClass.OrderByDescending(r => r.ID).Where(r => r.Delete == 0 ).Where(r => r.Publish == 1).ToList();
            List<NewsClassModels> result = new List<NewsClassModels>();
            for(int i = 0;i < limit && i < news.Count; i++)
            {
                result.Add(news[i]);
            }
            return View(result);
        }
    }
}