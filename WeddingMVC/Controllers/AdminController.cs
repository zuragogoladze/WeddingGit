using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeddingMVC.Filters;
using WeddingMVC.Models;


namespace WeddingMVC.Controllers
{
    [ModeratorFilter]
    public class AdminController : Controller
    {
        TestEntities _db = new TestEntities();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["logedInUser"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddPicture()
        {
            return View();
        }

        public JsonResult UploadFile()
        {
            User us = Session["logedInUser"] as User;
            string path = Server.MapPath("~/Content/Upload/");
            HttpFileCollectionBase files = Request.Files;

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Helper.Random32();
                HttpPostedFileBase file = files[i];

                using (Image image = Image.FromStream(file.InputStream))
                {
                    image.Save(path + fileName + ".png", ImageFormat.Png);
                }

                _db.Sliders.Add(new Slider
                {
                    Name = fileName,
                    CreateDate = DateTime.Now,
                    IsActive = false,
                    UserId = us.ID
                });
                _db.SaveChanges();
            }
            return Json(true);
        }

        public JsonResult Uploadgalery(string id)
        {
            var photographer = _db.Photographers.FirstOrDefault(x => x.ProfilePicture == id);
            string path = Server.MapPath("~/Content/img/galerypictures/");
            HttpFileCollectionBase files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Helper.Random32();
                HttpPostedFileBase file = files[i];
                using (Image image = Image.FromStream(file.InputStream))
                {
                    image.Save(path + fileName + ".png", ImageFormat.Png);
                }

                _db.PhotographerPictures.Add(new PhotographerPicture
                {
                    PhotographerID = photographer.ID,
                    PictureName = fileName,
                });
                _db.SaveChanges();
            }
            return Json(true);
        }

        public JsonResult UploadProfile()
        {
            string path = Server.MapPath("~/Content/img/desinerpictures/");
            HttpFileCollectionBase files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Helper.Random32();
                HttpPostedFileBase file = files[i];
                using (Image image = Image.FromStream(file.InputStream))
                {
                    image.Save(path + fileName + ".png", ImageFormat.Png);
                }
                _db.Photographers.Add(new Photographer
                {
                    Name = "11",
                    Email = "11",
                    Facebook = "11",
                    Information = "11",
                    Instagram = "11",
                    MobileNumber = "11",
                    ProfilePicture = fileName,
                    Surname = "11",
                    Profession = "11"
                });
                _db.SaveChanges();
                return Json(fileName, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UploadInfo(string name, string surname, string info, string number, string email, string facebook, string instagram, string picturename, int profession)
        {
            var result = _db.Photographers.FirstOrDefault(x => x.ProfilePicture == picturename);
            result.Name = name;
            result.Surname = surname;
            result.Email = email;
            result.Facebook = facebook;
            result.Information = info;
            result.Instagram = instagram;
            result.MobileNumber = number;
            result.Profession = profession==0 ? "ფოტოგრაფი" : "დიზაინერი";
            

            _db.SaveChanges();
            return Json(0);
        }

        public ActionResult ManagePictures()
        {
            return View(_db.Sliders);
        }
        public int ActivatePicture(int ID)
        {
            Slider picture = _db.Sliders.FirstOrDefault(x => x.ID == ID);
            if (picture.IsActive == true)
            {
                picture.IsActive = false;
                _db.SaveChanges();
                return 0;
            }
            else
            {
                picture.IsActive = true;
                _db.SaveChanges();
                return 1;
            }
        }

        public ActionResult AddPhotographer()
        {
            return View();
        }
    }
}