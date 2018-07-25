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
            var photographers = _db.Photographers;
            return View(photographers);
        }

        public ActionResult Photographer(string user)
        {
            var photographer = _db.Photographers.FirstOrDefault(x=>x.ProfilePicture==user);
            return View(photographer);
        }
        public ActionResult DesinerPage(string user)
        {
            var photographer = _db.Photographers.FirstOrDefault(x => x.ProfilePicture == user);
            return View(photographer);
        }
    }
}