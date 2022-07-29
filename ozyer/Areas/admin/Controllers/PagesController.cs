using ozyer.Areas.admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ozyer.Areas.admin.Controllers
{
    public class PagesController : Controller
    {
        // GET: admin/Pages
        public ActionResult Index()
        {

            using (ServiceDB db = new ServiceDB())
            {
                return View(db.Pages.Where(x => x.IsPassive == false).ToList());
            }
        }

        [HttpGet]
       
        public ActionResult create()
        {
            using (ServiceDB db = new ServiceDB())
            {
                return View("create", new Pages());
            }

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult create(Pages pages)
        {
            using (ServiceDB db = new ServiceDB())
            {

                if (pages.Id == 0)
                {
                    pages.Date = DateTime.Now;
                    pages.IsPassive = false;
                    pages.IsDeleted = false;

                    pages.FriendlyUrl = ozyer.Helpers.FriendlyUrl.FriendlyURLTitle(pages.Title);
                    db.Pages.Add(pages);
                    db.SaveChanges();
                    return Redirect("/admin/pages");
                }

                else
                {
                    var updateArea = db.Pages.Find(pages.Id);

                    if (updateArea == null)
                    {
                        return HttpNotFound();
                    }
                    updateArea.IsPassive = false;
                    updateArea.IsDeleted = false;
                    updateArea.Title = pages.Title;
                    updateArea.PageContent = pages.PageContent;
                    updateArea.FriendlyUrl = ozyer.Helpers.FriendlyUrl.FriendlyURLTitle(pages.Title);
                    db.SaveChanges();
                    return Redirect("/admin/pages");
                }
            }

        }

        public ActionResult update(int id)
        {
            using (ServiceDB db = new ServiceDB())
            {
                var pages = db.Pages.Find(id);
                if (pages == null)
                {
                    return HttpNotFound();
                }
                return View("create", pages);
            }

        }

        public ActionResult delete(int id)
        {
            using (ServiceDB db = new ServiceDB())
            {

                var currentPage = db.Pages.FirstOrDefault(x => x.Id == id);
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