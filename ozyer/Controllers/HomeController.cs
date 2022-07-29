using ozyer.Areas.admin.Model;
using ozyer.Models;
using System.Linq;
using System.Web.Mvc;

namespace ozyer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (ServiceDB db = new ServiceDB())
            {
                ServiceModel model = new ServiceModel();
                model.BlogList = db.Blog.Where(x => x.IsPassive == false).OrderByDescending(x => x.Date).ToList();
                model.workPartnerList = db.WorkPartners.ToList();
                model.ParticipationsGroupsList = db.ParticipationsGroups.Where(x => x.IsHide == false).ToList();
                model.SectorList = db.Sectors.ToList();
                model.Setting = db.Settings.ToList().Last();
                return View(model);

            }
        }

        [Route("iletisim")]
        public ActionResult iletisim()
        {

            return View();
        }
        [Route("hakkimizda")]
        public ActionResult hakkimizda()
        {
            return View();
        }

        [Route("sektor")]
        public ActionResult sektor()
        {
            return View();
        }
        [Route("sektorDetay")]
        public ActionResult sektorDetay()
        {
            return View();
        }
    }
}