using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Task
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/
        public ActionResult List()
        {
            return View("~/Views/Task/Index.cshtml");
        }
	}
}