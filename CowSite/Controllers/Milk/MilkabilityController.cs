using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Milk
{
    public class MilkabilityController : Controller
    {
        //
        // GET: /Milkability/
        public ActionResult Add()
        {
            return View("~/Views/Milk/Milkability/Add.cshtml");
        }
	}
}