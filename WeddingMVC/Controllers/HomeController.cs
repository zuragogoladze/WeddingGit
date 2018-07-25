using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeddingMVC.Models;

namespace WeddingMVC.Controllers
{
    public class HomeController : Controller
    {
        TestEntities _db = new TestEntities();
        // GET: Home
        public ActionResult Index()
        {
            var pictures = _db.Sliders.Where(x => x.IsActive == true);
            return View(pictures);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Planning()
        {
            return View();
        }

        public ActionResult Photographer()
        {
            return View();
        }
    }
}