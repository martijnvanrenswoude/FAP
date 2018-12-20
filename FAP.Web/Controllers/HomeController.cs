using FAP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FAP.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Inlogdata objUser)
        {
            if(ModelState.IsValid)
            {
                using(FAPDatabaseEntities fapEntities = new FAPDatabaseEntities())
                {
                    var obj = fapEntities.Inlogdatas.Where(a => a.username.Equals(objUser.username));
                    if(obj != null)
                    {
                        Session["UserID"] = objUser.Id.ToString();
                        Session["UserName"] = objUser.username.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}