using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FAP.Web.Controllers
{
    public class PlanningController : Controller
    {
        private readonly IPlanningRepository _planningRepository;

        public PlanningController(IPlanningRepository planningRepository)
        {
            _planningRepository = planningRepository;
        }
        public ActionResult Index()
        {
            var model = _planningRepository.GetAll();
            return View(model);
        }
    }
}