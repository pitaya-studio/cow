using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Medical
{
    /// <summary>
    /// 康复调群
    /// </summary>
    public class AdjustController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/CowGroup/Adjust.cshtml");
        }
	}
}