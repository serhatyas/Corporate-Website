using ozyer.Areas.admin.Model;
using ozyer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ozyer.Controllers
{
    public class kurumsalController : Controller
    {
        // GET: kurumsal
        [Route("kurumsal/{id}")]
        public ActionResult Index(string id)
        {
            using(ServiceDB db=new ServiceDB())
            {
                ServiceModel model = new ServiceModel();
                model.Page = db.Pages.FirstOrDefault(x => x.FriendlyUrl == id);
                model.Setting = db.Settings.ToList().Last();
                model.workPartnerList = db.WorkPartners.ToList();
                return View(model);

            }
        }
    }
}