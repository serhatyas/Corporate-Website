using ozyer.Areas.admin.Model;
using ozyer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ozyer.Areas.admin.Controllers
{
    public class settingsController : Controller
    {
        // GET: admin/settings
        public ActionResult Index()
        {
            using (ServiceDB db = new ServiceDB())
            {
                ServiceModel model = new ServiceModel();
                var settingList = db.Settings.ToList();
                if (settingList.Count != 0)
                    model.Setting
                        = settingList.Last();
                return View(model);

            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(ServiceModel model,HttpPostedFileBase file)
        {
            using (ServiceDB db = new ServiceDB())
            {
                var settingList = db.Settings.ToList();
                if (settingList.Count != 0)
                {
                    var setting = settingList.Last();
                    setting.Address = model.Setting.Address;
                    setting.CorporateValue = model.Setting.CorporateValue;
                    setting.Description = model.Setting.Description;
                    setting.Facebook = model.Setting.Facebook;
                    setting.FooterScripts = model.Setting.FooterScripts;
                    setting.GoogleMaps = model.Setting.GoogleMaps;
                    setting.HeadScripts = model.Setting.HeadScripts;
                    setting.Instagram = model.Setting.Instagram;
                    setting.LinkedIn = model.Setting.LinkedIn;
                    setting.Mail = model.Setting.Mail;
                    setting.Mission = model.Setting.Mission;
                    setting.Phone1 = model.Setting.Phone1;
                    setting.Phone2 = model.Setting.Phone2;
                    setting.Title = model.Setting.Title;
                    setting.Twitter = model.Setting.Twitter;
                    setting.UpdateDateTime = DateTime.Now;
                    setting.Vision = model.Setting.Vision;
                    setting.WorkHours = model.Setting.WorkHours;
                    if (file != null)
                    {
                        string filePath = System.IO.Path.Combine(Server.MapPath("/uploads/images/") + file.FileName);
                        file.SaveAs(filePath);
                        setting.Logo = "/uploads/images/" + file.FileName;
                    }
                }
                else
                {
                    string logoPAth = "";
                    if (file != null)
                    {
                        string filePath = System.IO.Path.Combine(Server.MapPath("/uploads/images/") + file.FileName);
                        file.SaveAs(filePath);
                        logoPAth = "/uploads/images/" + file.FileName;
                    }
                    db.Settings.Add(new Settings
                    {
                        Address = model.Setting.Address,
                        CorporateValue = model.Setting.CorporateValue,
                        Date = DateTime.Now,
                        Description = model.Setting.Description,
                        Facebook = model.Setting.Facebook,
                        FooterScripts = model.Setting.FooterScripts,
                        GoogleMaps = model.Setting.GoogleMaps,
                        HeadScripts = model.Setting.HeadScripts,
                        Instagram = model.Setting.Instagram,
                        LinkedIn = model.Setting.LinkedIn,
                        Mail = model.Setting.Mail,
                        Mission = model.Setting.Mission,
                        Phone1 = model.Setting.Phone1,
                        Phone2 = model.Setting.Phone2,
                        Title = model.Setting.Title,
                        Twitter = model.Setting.Twitter,
                        UpdateDateTime = DateTime.Now,
                        Vision = model.Setting.Vision,
                        WorkHours = model.Setting.WorkHours,
                        Logo= logoPAth
                    });
                   
                }
                db.SaveChanges();

                TempData["SettingSuccess"] = "Basarili";
                return Redirect("/admin/settings");

            }

        }
    }
}