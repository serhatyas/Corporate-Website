using ozyer.Areas.admin.Model;
using ozyer.Helpers;
using ozyer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ozyer.Areas.admin.Controllers
{
    public class blogController : Controller
    {
        // GET: admin/blog
        public ActionResult Index()
        {
            using(ServiceDB db=new ServiceDB())
            {
                ServiceModel model = new ServiceModel();
                model.BlogList = db.Blog.Where(x => x.IsPassive == false).ToList();
                return View(model);

            }
        }

        [HttpGet]
        public ActionResult Save(int id=0)
        {
            using (ServiceDB db = new ServiceDB())
            {
                ServiceModel model = new ServiceModel();
                if(id!=0)
                {
                    model.Blog = db.Blog.FirstOrDefault(x => x.Id == id);
                }
                return View(model);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(ServiceModel model,HttpPostedFileBase file)
        {
            using (ServiceDB db = new ServiceDB())
            {
                string path = "";
                if (file != null)
                {
                    string filePath = System.IO.Path.Combine(Server.MapPath("/uploads/images/") + file.FileName);
                    file.SaveAs(filePath);
                    path = "/uploads/images/" + file.FileName;
                }
                if (model.Blog.Id!=0)
                {
                    var currentBlog = db.Blog.FirstOrDefault(x => x.Id == model.Blog.Id);
                    if (path != "")
                        currentBlog.Photo = path;
                    currentBlog.Author = model.Blog.Author;
                    currentBlog.Date = DateTime.Now;
                    currentBlog.Description = model.Blog.Description;
                    currentBlog.Name = model.Blog.Name;
                    currentBlog.ShortDescription = model.Blog.ShortDescription;
                    currentBlog.FriendlyUrl = FriendlyUrl.FriendlyURLTitle(model.Blog.Name);
                }
                else
                {
                    model.Blog.FriendlyUrl= FriendlyUrl.FriendlyURLTitle(model.Blog.Name);
                    model.Blog.Photo = path;
                    model.Blog.Date = DateTime.Now;
                    model.Blog.IsPassive = false;
                    db.Blog.Add(model.Blog);
                }
                db.SaveChanges();
                return Redirect("/admin/blog");

            }
        }


        public ActionResult delete(int id)
        {
            using (ServiceDB db = new ServiceDB())
            {

                var currentPage = db.Blog.FirstOrDefault(x => x.Id == id);
                if (currentPage != null)
                {
                    currentPage.IsPassive = true;
                    db.SaveChanges();
                    return Json("basarili", JsonRequestBehavior.AllowGet);
                }
                return View();
            }

        }
    }
}