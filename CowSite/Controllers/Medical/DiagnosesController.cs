﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Medical
{
    public class DiagnosesController : Controller
    {
        public ActionResult Add()
        {
            return View("~/Views/Medical/Diagnoses/Add.cshtml");
        }
	}
}