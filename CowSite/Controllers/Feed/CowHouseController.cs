using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Feed
{
    /// <summary>
    /// 牛舍维护
    /// </summary>
    public class CowHouseController : Controller
    {
        public ActionResult List()
        {
            return View("~/Views/Feed/CowHouse/List.cshtml");
        }
	}
}