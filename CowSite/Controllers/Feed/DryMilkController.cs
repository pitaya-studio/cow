using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Feed
{
    /// <summary>
    /// 干奶
    /// </summary>
    public class DryMilkController : Controller
    {
        //
        // GET: /DryMilk/
        public ActionResult Add()
        {
            return View("~/Views/Feed/DryMilk/Add.cshtml");
        }
    }
}