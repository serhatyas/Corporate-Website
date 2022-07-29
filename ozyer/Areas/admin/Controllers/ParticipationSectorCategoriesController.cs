using ozyer.Areas.admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ozyer.Areas.admin.Controllers
{
    public class ParticipationSectorCategoriesController : Controller
    {
        // GET: admin/ParticipationSectorCategories
        // GET: admin/users
        public ActionResult Index()
        {

            using (ServiceDB db = new ServiceDB())
            {
                return View(db.ParticipationSectorCategories.ToList());
            }
        }

        [HttpGet]
        public ActionResult create()
        {
            using (ServiceDB db = new ServiceDB())
            {
                return View();
            }

        }
        [HttpPost]
        public ActionResult create(ParticipationSectorCategories category)
        {
            using (ServiceDB db = new ServiceDB())
            {
                db.ParticipationSectorCategories.Add(category);
                db.SaveChanges();
                return Redirect("/admin/ParticipationSectorCategories");
            }

        }
        [HttpGet]
        public ActionResult update(int id)
        {
            using (ServiceDB db = new ServiceDB())
            {
                return View(db.ParticipationSectorCategories.FirstOrDefault(x => x.Id == id));
            }

        }
        [HttpPost]
        public ActionResult update(ParticipationSectorCategories category)
        {
            using (ServiceDB db = new ServiceDB())
            {
                var currentCategory = db.ParticipationSectorCategories.FirstOrDefault(x => x.Id == category.Id);
                currentCategory.Name = category.Name;
                db.SaveChanges();
                return Redirect("/admin/ParticipationSectorCategories");
            }

        }
        public ActionResult delete(int id)
        {
            using (ServiceDB db = new ServiceDB())
            {

                var currentCategory = db.ParticipationSectorCategories.FirstOrDefault(x => x.Id == id);
                if (currentCategory != null)
                {
                    db.ParticipationSectorCategories.Remove(currentCategory);
                    db.SaveChanges();
                    return Json("basarili", JsonRequestBehavior.AllowGet);
                }
                return View();
            }

        }
    }
}