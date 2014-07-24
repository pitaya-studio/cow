using Common;
using CowSite.Base;
using DairyCow.BLL;
using DairyCow.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CowSite.Controllers.Platform
{
    public class FormulaController : Controller
    {
        private FormulaBLL bllFormula = new FormulaBLL();

        public ActionResult List()
        {
            return View("~/Views/Platform/Formula/List.cshtml");
        }

        public ActionResult Modify()
        {
            ViewBag.PastureID = UserBLL.Instance.CurrentUser.Pasture.ID;
            ViewBag.FormulaID = Request.QueryString["FormulaID"];
            return View("~/Views/Platform/Formula/Modify.cshtml");
        }

        public JsonResult GetFormulaList()
        {
            List<Formula> lstFormula = this.bllFormula.GetFormulaList();
            return Json(lstFormula, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFormulaInfoList(string formulaID)
        {
            Formula formula = this.bllFormula.GetFormulaInfoList(formulaID);
            var cowGroupData = new
            {
                FormulaID = formula.ID,
                FormulaName = formula.Name,
                Rows = formula.FodderList
            };
            return Json(cowGroupData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveFormula(string formulaID, string formulaName, string fodderQuantity)
        {
            List<Fodder> lstFodder = Utility.Deserialize<List<Fodder>>(fodderQuantity);
            this.bllFormula.SaveFormula(formulaID, formulaName, lstFodder);
            var result = new
            {
                result = 1
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Assign()
        {
            return View("~/Views/Platform/Formula/Assign.cshtml");
        }
	}
}