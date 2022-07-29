using ozyer.Areas.admin.Model;
using ozyer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ozyer.Areas.admin.Controllers
{
    public class contactController : Controller
    {
        // GET: admin/contact
        public ActionResult Index()
        {
            using (ServiceDB db = new ServiceDB())
            {
                ServiceModel model = new ServiceModel();
                model.ContactMessageList = db.ContactMessages.Where(x => x.IsPassive == false).ToList();
                return View(model);
            }
        }
    }
}