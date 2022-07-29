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
    public class workPartnersController : Controller
    {
        // GET: admin/workPartners
        public ActionResult Index()
        {

            using (ServiceDB db = new ServiceDB())
            {
                ServiceModel model = new ServiceModel();
                model.SectorList = db.Sectors.ToList();
                model.ParticipationsGroupsList = db.ParticipationsGroups.ToList();
                model.workPartnerList = db.WorkPartners.Where(x => x.IsPassive == false).ToList();
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult create()
        {
            using (ServiceDB db = new ServiceDB())
            {
                ServiceModel model = new ServiceModel();
                model.SectorList = db.Sectors.Where(x => x.IsPassive == false).ToList();
                model.ParticipationsGroupsList = db.ParticipationsGroups.ToList();
                return View(model);
            }

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult create(WorkPartners workPartners, HttpPostedFileBase Images, HttpPostedFileBase Logo, HttpPostedFileBase[] gallery)
        {
            using (ServiceDB db = new ServiceDB())
            {
                workPartners.FriendlyUrl = FriendlyUrl.FriendlyURLTitle(workPartners.Name);
                workPartners.IsPassive = false;
                if (Logo != null)
                {
                    string filePath = System.IO.Path.Combine(Server.MapPath("/uploads/images/") + Logo.FileName);
                    Logo.SaveAs(filePath);
                    workPartners.Logo = "/uploads/images/" + Logo.FileName;

                }
                if (Images != null)
                {
                    string filePath = System.IO.Path.Combine(Server.MapPath("/uploads/images/") + Images.FileName);
                    Images.SaveAs(filePath);
                    workPartners.Image = "/uploads/images/" + Images.FileName;

                }
                db.WorkPartners.Add(workPartners);
                db.SaveChanges();
                foreach (var item in gallery)
                {
                    if (item != null)
                    {

                        string filePath = System.IO.Path.Combine(Server.MapPath("/uploads/images/") + item.FileName);
                        item.SaveAs(filePath);
                        db.WorkPartnerFiles.Add(new WorkPartnerFiles()
                        {
                            Date = DateTime.Now,
                            IsPassive = false,
                            Path = "/uploads/images/" + item.FileName,
                            WorkPartnerId = workPartners.Id
                        });
                    }
                }
                db.SaveChanges();
                return Redirect("/admin/WorkPartners");
            }

        }
        [HttpGet]
        public ActionResult update(int id)
        {
            using (ServiceDB db = new ServiceDB())
            {
                return View(db.WorkPartners.FirstOrDefault(x => x.Id == id));
            }

        }
        [HttpPost]
        [ValidateInput(false)]

        public ActionResult update(WorkPartners workPartners, HttpPostedFileBase Images, HttpPostedFileBase Logo, HttpPostedFileBase[] gallery)
        {
            using (ServiceDB db = new ServiceDB())
            {
                var currentCategory = db.WorkPartners.FirstOrDefault(x => x.Id == workPartners.Id);
                foreach (var item in gallery)
                {
                    if (item != null)
                    {

                        string filePath = System.IO.Path.Combine(Server.MapPath("/uploads/images/") + item.FileName);
                        item.SaveAs(filePath);
                        db.WorkPartnerFiles.Add(new WorkPartnerFiles()
                        {
                            Date = DateTime.Now,
                            IsPassive = false,
                            Path = "/uploads/images/" + item.FileName,
                            WorkPartnerId = currentCategory.Id
                        });
                    }
                }
                if (Logo != null)
                {
                    string filePath = System.IO.Path.Combine(Server.MapPath("/uploads/images/") + Logo.FileName);
                    Logo.SaveAs(filePath);
                    currentCategory.Logo = "/uploads/images/" + Logo.FileName;

                }
                if (Images != null)
                {
                    string filePath = System.IO.Path.Combine(Server.MapPath("/uploads/images/") + Images.FileName);
                    Images.SaveAs(filePath);
                    currentCategory.Image = "/uploads/images/" + Images.FileName;

                }
                currentCategory.Name = workPartners.Name;
                currentCategory.Address = workPartners.Address;
                currentCategory.Description = workPartners.Description;
                currentCategory.Phone = workPartners.Phone;
                currentCategory.WebSite = workPartners.WebSite;
                currentCategory.FriendlyUrl = FriendlyUrl.FriendlyURLTitle(workPartners.Name);
                currentCategory.IsPassive = false;
                db.SaveChanges();
                return Redirect("/admin/WorkPartners");
            }

        }
        public ActionResult delete(int id)
        {
            using (ServiceDB db = new ServiceDB())
            {

                var currentCategory = db.WorkPartners.FirstOrDefault(x => x.Id == id);
                if (currentCategory != null)
                {
                    db.WorkPartners.Remove(currentCategory);
                    db.SaveChanges();
                    return Json("basarili", JsonRequestBehavior.AllowGet);
                }
                return View();
            }

        }
    }
}