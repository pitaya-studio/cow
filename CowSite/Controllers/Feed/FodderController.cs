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
            List<Fodder> lstFodder = bllFodder.GetPastureFodders(pastureID);
            var fodderData = new
            {
                Rows = lstFodder
            };
            return Json(fodderData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFodderOfFormula(string formulaID)
        {
            List<Fodder> lstFodder = bllFodder.GetFodderList(Convert.ToInt32(formulaID));
            var fodderData = new
            {
                Rows = lstFodder
            };
            return Json(fodderData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGroups()
        {
            CowGroupBLL groupBLL = new CowGroupBLL();
            List<CowGroup> groups = groupBLL.GetCowGroupList(UserBLL.Instance.CurrentUser.Pasture.ID);
            return Json(groups, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFormulaFodders(int formulaID)
        {
            FormulaBLL fBLL = new FormulaBLL();
            if (formulaID!=0)
            {
                //fBLL.
            }
            
            return Json(groups, JsonRequestBehavior.AllowGet);
        }
	}
}