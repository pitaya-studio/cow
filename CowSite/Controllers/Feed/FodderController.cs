using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Feed
{
    public class FodderController : Controller
    {
        FodderBLL bllFodder = new FodderBLL();

        public ActionResult Maintain()
        {
            return View("~/Views/Feed/Fodder/Maintain.cshtml");
        }

        public ActionResult Calculate()
        {
            return View("~/Views/Feed/Fodder/Calculate.cshtml");
        }

        public ActionResult Raise()
        {
            return View("~/Views/Feed/Fodder/Raise.cshtml");
        }

        public JsonResult GetFodder(int pastureID)
        {
            List<Fodder> lstFodder = bllFodder.GetFodder(pastureID);
            var fodderData = new
            {
                Rows = lstFodder
            };
            return Json(fodderData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFodderOfFormula(string formulaID)
        {
            List<Fodder> lstFodder = bllFodder.GetFodder(formulaID);
            var fodderData = new
            {
                Rows = lstFodder
            };
            return Json(fodderData, JsonRequestBehavior.AllowGet);
        }
	}
}