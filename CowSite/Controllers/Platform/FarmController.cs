using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Platform
{
    /// <summary>
    /// 平台-牧场管理
    /// </summary>
    public class FarmController : Controller
    {
        public ActionResult List()
        {
            return View("~/Views/Platform/Farm/List.cshtml");
        }
	}
}