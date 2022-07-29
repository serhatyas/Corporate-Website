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
    public class ParticipationController : Controller
    {
        // GET: admin/Participation
        public ActionResult Index()
        {
            using (ServiceDB db = new ServiceDB())
            {
                return View(db.Participations.Where(x => x.IsDeleted == false && x.IsPassive == false).ToList());

            }
        }
        [HttpGet]
        public ActionResult create()
        {
            using (ServiceDB db = new ServiceDB())
            {
                ServiceModel model = new ServiceModel();
                model.SectorList = db.Sectors.ToList();
                model.ParticipationsGroupsList = db.ParticipationsGroups.ToList();
                return View(model);
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult create(ServiceModel model, HttpPostedFileBase file)
        {
            using (ServiceDB db = new ServiceDB())
            {
                model.Participations.Date = DateTime.Now;
                model.Participations.IsDeleted = false;
                model.Participations.IsPassive = false;
                model.Participations.FriendlyUrl = FriendlyUrl.FriendlyURLTitle(model.Participations.Name);
                if (file != null)
                {
                    string filePath = System.IO.Path.Combine(Server.MapPath("/uploads/images/") + file.FileName);
                    file.SaveAs(filePath);
                    model.Participations.Logo = "/uploads/images/" + file.FileName;
                }
                db.Participations.Add(model.Participations);
                db.SaveChanges();
                return Redirect("/admin/Participation");

            }
        }

        [HttpGet]
        public ActionResult update(int id)
        {
            using (ServiceDB db = new ServiceDB())
            {
                ServiceModel model = new ServiceModel();
                model.Participations =db.Participations.FirstOrDefault(x => x.Id == id);
                model.SectorList = db.Sectors.ToList();
                model.ParticipationsGroupsList = db.ParticipationsGroups.ToList();
                return View(model);

            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult update(ServiceModel model, HttpPostedFileBase file)
        {
            using (ServiceDB db = new ServiceDB())
            {
                var currentPart = db.Participations.FirstOrDefault(x => x.Id == model.Participations.Id);
                if (file != null)
                {
                    string filePath = System.IO.Path.Combine(Server.MapPath("/uploads/images/") + file.FileName);
                    file.SaveAs(filePath);
                    currentPart.Logo = "/uploads/images/" + file.FileName;
                }
                currentPart.FriendlyUrl = FriendlyUrl.FriendlyURLTitle(model.Participations.Name);
                currentPart.Name = model.Participations.Name;
                currentPart.Address = model.Participations.Address;
                currentPart.Description = model.Participations.Description;
                currentPart.Website = model.Participations.Website;
                currentPart.Phone = model.Participations.Phone;
                //currentPart.Website = model.Participations.Website;
                currentPart.ParticipationsGroupId = model.Participations.ParticipationsGroupId;
                currentPart.SectorId = model.Participations.SectorId;
                db.SaveChanges();
                return Redirect("/admin/Participation");


            }
        }


        public ActionResult delete(int id)
        {
            using (ServiceDB db = new ServiceDB())
            {
                var currentPart = db.Participations.FirstOrDefault(x => x.Id == id);
                if (currentPart != null)
                {
                    currentPart.IsDeleted = true;
                    db.SaveChanges();
                    return Json("basarili", JsonRequestBehavior.AllowGet);
                }
                return View();

            }
        }
    }
}