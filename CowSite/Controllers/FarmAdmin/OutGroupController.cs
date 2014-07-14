using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.FarmAdmin
{
    public class OutGroupController : Controller
    {
        public ActionResult List()
        {
            return View("~/Views/FarmAdmin/OutGroup/List.cshtml");
        }
	}
}