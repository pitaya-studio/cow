using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Milk
{
    public class MilkabilityCheckController : Controller
    {
        public ActionResult Add()
        {
            return View("~/Views/Milk/MilkabilityCheck/Add.cshtml");
        }
	}
}