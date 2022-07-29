using ozyer.Areas.admin.Model;
using ozyer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ozyer.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        [HttpGet]

        public ActionResult Index()
        {
            using (ServiceDB db = new ServiceDB())
            {
                ServiceModel model = new ServiceModel();
                model.ContactMessageList = db.ContactMessages.Where(x => x.IsPassive == false).ToList();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Index(ServiceModel model)
        {
            using (ServiceDB db = new ServiceDB())
            {
                model.ContactMessage.IsDeleted = false;
                model.ContactMessage.IsPassive = false;
                model.ContactMessage.Date = DateTime.Now;
                db.ContactMessages.Add(model.ContactMessage);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Mesajınız başarıyla gönderildi";
                return View();
            }

        }

     
    }
}