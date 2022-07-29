using ozyer.Areas.admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ozyer.Areas.admin.Controllers
{
    public class usersController : Controller
    {
        // GET: admin/users
        public ActionResult Index()
        {

            using (ServiceDB db = new ServiceDB())
            {
                return View(db.Users.Where(x=>x.IsPassive==false).ToList());
            }
        }

        [HttpGet]
        public ActionResult create()
        {
            using(ServiceDB db=new ServiceDB())
            {
                return View("create", new Users());
            }
                
        }

        [HttpPost]
        public ActionResult create(Users user)
        {
            using (ServiceDB db = new ServiceDB())
            {

                if (user.Id==0)
                {
                    user.Date = DateTime.Now;
                    user.IsPassive = false;
                    db.Users.Add(user);
                    db.SaveChanges();
                    return Redirect("/admin/users");
                }

                else
                {
                    var updateArea = db.Users.Find(user.Id);
                    if(updateArea==null)
                    {
                        return HttpNotFound();
                    }
                    updateArea.NameSurname = user.NameSurname;
                    updateArea.Mail = user.Mail;
                    updateArea.Password = user.Password;
                    db.SaveChanges();
                    return Redirect("/admin/users");
                }
            }

        }
        public ActionResult update(int id)
        {
            using (ServiceDB db = new ServiceDB())
            {
                var user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View("create", user);
            }

        }

        public ActionResult delete(int id)
        {
            using (ServiceDB db = new ServiceDB())
            {

                var currentUser = db.Users.FirstOrDefault(x => x.Id == id);
                if(currentUser!=null)
                {
                    currentUser.IsPassive = true;
                    db.SaveChanges();
                    return Json("basarili", JsonRequestBehavior.AllowGet);
                }
                return View();
            }

        }
    }
}