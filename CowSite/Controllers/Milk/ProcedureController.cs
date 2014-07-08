using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Milk
{
    public class ProcedureController : Controller
    {
        //
        // GET: /Procedure/
        public ActionResult Milking()
        {
            return View("~/Views/Milk/Procedure/Milking.cshtml");
        }
	}
}