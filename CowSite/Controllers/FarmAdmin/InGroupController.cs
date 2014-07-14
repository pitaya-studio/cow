using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.FarmAdmin
{
    public class InGroupController : Controller
    {
        public ActionResult List()
        {
            return View("~/Views/FarmAdmin/InGroup/List.cshtml");
        }
	}
}