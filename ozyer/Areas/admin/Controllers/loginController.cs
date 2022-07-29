using ozyer.Areas.admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ozyer.Areas.admin.Controllers
{
    public class loginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using(ServiceDB db=new ServiceDB())
            {
                return View();

            }
        }
        [HttpPost]
        public ActionResult Index(Users user,bool RememberMe)
        {
            using (ServiceDB db = new ServiceDB())
            {
                var CurrentUser = db.Users.FirstOrDefault(x => x.Mail == user.Mail && x.Password == user.Password);
                if(CurrentUser!=null)
                {
                    FormsAuthentication.SetAuthCookie(CurrentUser.Mail, true);
                    return Redirect("/admin/dashboard");
                }
                ViewBag.Hata = "Kullanıcı adınızı veya şifrenizi hatalı girdiniz.";
                return View();

            }
        }
    }
}