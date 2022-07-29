using ozyer.Areas.admin.Model;
using ozyer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ozyer.Areas.admin.Controllers
{
    public class sectorController : Controller
    {
        // GET: sector
        public ActionResult Index()
        {
            using (ServiceDB db = new ServiceDB())
            {

                ServiceModel model = new ServiceModel();
                model.SectorList = db.Sectors.Where(x => x.IsPassive == false).ToList();
                return View(model);

            }
        }
        [HttpGet]
        public ActionResult create()
        {
            using (ServiceDB db = new ServiceDB())
            {
                ServiceModel model = new ServiceModel();
                return View();

            }
        }
        [HttpPost]
        public ActionResult create(Sectors model, HttpPostedFileBase file)
        {
            using (ServiceDB db = new ServiceDB())
            {
                try
                {
                    model.Date = DateTime.Now;
                    if (file != null)
                    {
                        string filePath = System.IO.Path.Combine(Server.MapPath("/uploads/images/") + file.FileName);
                        file.SaveAs(filePath);
                        model.Icon = "/uploads/images/" + file.FileName;
                    }

                    model.IsPassive = false;
                    db.Sectors.Add(model);
                    db.SaveChanges();
                    return Redirect("/admin/sector");
                }
                catch (Exception)
                {
                    return Redirect("/admin/login");
                }

            }
        }
        [HttpGet]
        public ActionResult update(int id)
        {
            using (ServiceDB db = new ServiceDB())
            {
                var sector = db.Sectors.FirstOrDefault(x => x.Id == id);
                return View(sector);

            }
        }
        [HttpPost]
        public ActionResult update(Sectors model, HttpPostedFileBase file)
        {
            using (ServiceDB db = new ServiceDB())
            {
                var currenSector = db.Sectors.FirstOrDefault(x => x.Id == model.Id);
                if (file != null)
                {
                    string filePath = System.IO.Path.Combine(Server.MapPath("/uploads/images/") + file.FileName);
                    file.SaveAs(filePath);
                    currenSector.Icon = "/uploads/images/" + file.FileName;
                }
                currenSector.Name = model.Name;
                currenSector.Description = model.Description;
                db.SaveChanges();
                return Redirect("/admin/sector");

            }
        }

        public ActionResult delete(int id)
        {
            using (ServiceDB db = new ServiceDB())
            {
                var currentSector = db.Sectors.FirstOrDefault(x => x.Id == id);
                if(currentSector!=null)
                {
                    currentSector.IsPassive = true;
                    db.SaveChanges();
                }
                return Json("basarili", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ImageUpload(HttpPostedFileBase uploadfile)
        {
            if (uploadfile.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/Content/images"), Guid.NewGuid().ToString() + "_" + Path.GetFileName(uploadfile.FileName));
                uploadfile.SaveAs(filePath);
            }
            return View();
        }
    }
}