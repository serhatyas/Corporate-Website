using ozyer.Areas.admin.Model;
using ozyer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ozyer.Controllers
{
    public class blogController : Controller
    {
        // GET: blog
        public ActionResult Index()
        {
            using (ServiceDB db = new ServiceDB())
            {
                ServiceModel model = new ServiceModel();
                model.BlogList = db.Blog.Where(x => x.IsPassive == false).OrderByDescending(x => x.Date).ToList();
                return View(model);

            }
        }

        [Route("blog/{id}")]
        public ActionResult detay(string id)
        {
            using(ServiceDB db=new ServiceDB())
            {
                ServiceModel model = new ServiceModel();
                model.Blog = db.Blog.FirstOrDefault(x => x.FriendlyUrl == id);
                return View(model);

            }
        }
    }
}