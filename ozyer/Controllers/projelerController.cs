using ozyer.Areas.admin.Model;
using ozyer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ozyer.Controllers
{
    public class projelerController : Controller
    {
        // GET: projeler
        [Route("projeler/{id}")]
        public ActionResult Index(string id)
        {
            using(ServiceDB db=new ServiceDB())
            {
                ServiceModel model = new ServiceModel();
                model.workPartners = db.WorkPartners.FirstOrDefault(x => x.FriendlyUrl == id);
                model.SectorList = db.Sectors.ToList();
                model.ParticipationsGroupsList = db.ParticipationsGroups.ToList();
                model.workPartnerList = db.WorkPartners.Where(x => x.SectorId == model.workPartners.SectorId && x.IsPassive==false && x.Id!=model.workPartners.Id).ToList();
                model.WorkPartnerFileList = db.WorkPartnerFiles.Where(x => x.WorkPartnerId == model.workPartners.Id && x.IsPassive == false).ToList();
                return View(model);

            }
        }
    }
}