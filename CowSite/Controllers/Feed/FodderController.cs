using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DairyCow.DAL;

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
            List<PastureFodder> lstFodder = bllFodder.GetPastureFodders(pastureID);
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

        public JsonResult GetHouses(int groupID)
        {
            HouseBLL hBLL = new HouseBLL();
            List<House> houses = hBLL.GetHouseListByGroup(UserBLL.Instance.CurrentUser.Pasture.ID, groupID);
            return Json(houses, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFormulaFodders(int formulaID)
        {
            FodderBLL fBLL = new FodderBLL();
            List<PastureFodder> list=new List<PastureFodder>();
            if (formulaID!=0)
            {
                list=fBLL.GetMappedPastureFodders(formulaID, UserBLL.Instance.CurrentUser.Pasture.ID);
            }
            
            return Json(list, JsonRequestBehavior.AllowGet);
            
        }

        public JsonResult CheckFormulaFodders(int formulaID)
        {
            FodderBLL fBLL = new FodderBLL();
            FormulaBLL formulaBLL = new FormulaBLL();
            string formulaName; 
            List<PastureFodder> list = new List<PastureFodder>();
            List<Fodder> sList=new List<Fodder>();
            string msg;
            int result;
            if (formulaID != 0)
            {
                list = fBLL.GetMappedPastureFodders(formulaID, UserBLL.Instance.CurrentUser.Pasture.ID);
                sList = fBLL.GetFodderList(formulaID);
                formulaName = formulaBLL.GetFormulaList().Find(p => p.ID == formulaID).Name;
                if (sList.Count == list.Count)
                {
                    //饲料匹配
                    msg = "配方Ready!";
                    result = 0;
                    
                }
                else
                {
                    msg = "本配方存在未匹配的标准饲料。";
                    result = 1;
                    
                }
            }
            else
            {
                msg = "未找到配方。请联系运营方指定配方。";
                result = 2;
                formulaName = "";
            }
            
            CheckFodderResult r = new CheckFodderResult()
            {
                Msg = msg,
                Result = result,
                FormulaName = formulaName
            };
            return Json(r, JsonRequestBehavior.AllowGet);

        }
        public struct CheckFodderResult
        {
            public string Msg;
            public int Result;
            public string FormulaName;
        }
	}
}