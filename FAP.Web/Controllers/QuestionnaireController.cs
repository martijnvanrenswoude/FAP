using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FAP.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        // GET: Vragenlijst
        public ActionResult Index()
        {
            return View();
        }
    }
}