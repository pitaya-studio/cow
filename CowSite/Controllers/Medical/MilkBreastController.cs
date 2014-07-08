using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Medical
{
    public class MilkBreastController : Controller
    {
        //
        // GET: /MilkBreast/
        public ActionResult Add()
        {
            return View("~/Views/Medical/MilkBreast/Add.cshtml");
        }
	}
}