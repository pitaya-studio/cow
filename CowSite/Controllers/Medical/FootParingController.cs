using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Medical
{
    public class FootParingController : Controller
    {
        //
        // GET: /FootParing/
        public ActionResult Add()
        {
            return View("~/Views/Medical/FootParing/Add.cshtml");
        }
	}
}