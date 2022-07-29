using ozyer.Areas.admin.Model;
using ozyer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ozyer.Controllers
{
    public class istiraklerController : Controller
    {
        // GET: istirakler
        [Route("istirakler/{id}")]
        public ActionResult Index(string id)
        {
            using(ServiceDB db=new ServiceDB())
            {
                ServiceModel model = new ServiceModel();
                model.Participations = db.Participations.FirstOrDefault(x => x.FriendlyUrl == id);
                model.SectorList = db.Sectors.ToList();
                model.ParticipationsGroupsList = db.ParticipationsGroups.ToList();
                model.workPartnerList = db.WorkPartners.Where(x => x.ParticipationsGroupId == model.Participations.ParticipationsGroupId &&
                x.SectorId == model.Participations.SectorId).ToList();
                model.WorkPartnerFileList = db.WorkPartnerFiles.ToList();
                return View(model);

            }
        }
    }
}