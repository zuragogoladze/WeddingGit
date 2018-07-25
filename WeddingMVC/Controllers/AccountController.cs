using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeddingMVC.Models;
using WeddingMVC.Filters;

namespace WeddingMVC.Controllers
{
    public class AccountController : Controller
    {
        TestEntities _db = new TestEntities();
        // GET: Account
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [RoleFilter]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Registration(newUser u)
        {
            if (u.password != u.passwordRepeat)
            {
                return Json(new
                {
                    status = 1
                });
            }

            if (string.IsNullOrWhiteSpace(u.name) || string.IsNullOrWhiteSpace(u.password) ||
                string.IsNullOrWhiteSpace(u.passwordRepeat) || string.IsNullOrWhiteSpace(u.email) ||
                string.IsNullOrWhiteSpace(u.surname))
            {
                return Json(new
                {
                    status = 1,
                    responseObject = u
                });
            }

            try
            {
                User us = new User
                {
                    Name = u.name,
                    Surname = u.surname,
                    Email = u.email,
                    Role = 50,
                    Password = Helper.MD5Hash(u.password),
                    ResetPassword = Helper.Random32()
                };
                _db.Users.Add(us);
                _db.SaveChanges();
                return Json(new
                {
                    status = 2
                });
            }

            catch
            {
                return Json(new
                {
                    status = 3
                });
            }

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login (string email, string password)
        {
            var user = _db.Users.FirstOrDefault(x => x.Email == email);
            if (user==null)
            {
                return Json(1);
            }

            if (string.IsNullOrWhiteSpace(email)||string.IsNullOrWhiteSpace(password))
            {
                return Json(0);
            }

            Session["logedInUser"] = user;
            return Json(2);
        }
    }
}