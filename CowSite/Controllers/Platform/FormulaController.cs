using Common;
using CowSite.Base;
using DairyCow.BLL;
using DairyCow.Model;
using System.Collections.Generic;
using System.Web.Mvc;
using System;

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
            Formula formula = this.bllFormula.GetFormulaByIDWithFodders(formulaID);
            var formulaData = new
            {
                ID = formula.ID,
                Name = formula.Name,
                Rows = formula.FodderList
            };
            return Json(formulaData, JsonRequestBehavior.AllowGet);
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

        //assign formula related json
        public JsonResult GetCowGroupInfo(string areAll)
        {
            CowGroupBLL bllCowGroup = new CowGroupBLL();
            List<CowGroup> lstCowGroup = bllCowGroup.GetCowGroupList();
            List<CowGroup> list=lstCowGroup.FindAll(p=> p.FormulaID==0);
            bool all = Int32.Parse(areAll) == 1 ? true : false;
            if (all)
            {
                var cowGroupData = new
                {
                    Rows = lstCowGroup
                };
                return Json(cowGroupData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var cowGroupData = new
                {
                    Rows = list
                };
                return Json(cowGroupData, JsonRequestBehavior.AllowGet);
            }           
        }

        public JsonResult GetFormulas()
        {
            FormulaBLL fBLL = new FormulaBLL();
            List<Formula> list = fBLL.GetFormulaList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateFormula(string cowGroupID,  string formulaID)
        {
            CowGroupBLL cBLL = new CowGroupBLL();
            int gID = Int32.Parse(cowGroupID);
            int fID = Int32.Parse(formulaID);
            int i2 = cBLL.UpdateCowGroupFormula(gID, fID);
            var result = new { Count =  i2  };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}