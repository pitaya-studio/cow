using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Platform
{
    /// <summary>
    /// 平台-饲料管理
    /// </summary>
    public class FodderController : Controller
    {
        public ActionResult List()
        {
            return View("~/Views/Platform/Fodder/List.cshtml");
        }
	}
}