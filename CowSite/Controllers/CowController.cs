using DairyCow.BLL;
using DairyCow.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CowSite.Controllers
{
    public class CowController : Controller
    {
        CowBLL bllCow = new CowBLL();

        public ActionResult AssignGroup()
        {
            return View();
        }
        /// <summary>
        /// 牛档案卡Controller
        /// </summary>
        /// <returns></returns>
        public ActionResult CowDetail()
        {
            ViewBag.DisplayEarNum = Request.QueryString["displayEarNum"];
            return View("~/Views/Cow/Detail.cshtml");
        }

        public JsonResult GetCowInfo(string displayEarNum)
        {
            int earNum = CowBLL.ConvertDislayEarNumToEarNum(displayEarNum, UserBLL.Instance.CurrentUser.Pasture.ID);
            CowInfo myCow = new CowInfo(earNum);
            return Json(myCow, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CowList()
        {
            ViewBag.CowType = Request.QueryString["cowType"];
            return View("~/Views/Cow/List.cshtml");
        }

        public JsonResult GetCowList(string cowType)
        {
            FarmInfo farm = new FarmInfo(UserBLL.Instance.CurrentUser.Pasture.ID);

            List<CowInfo> cowList = new List<CowInfo>();

            switch (cowType)
            {
                case "经产牛":
                    cowList = farm.MultiParityCows;
                    break;
                case "青年牛":
                    cowList = farm.NullParityCows;
                    break;
                case "育成牛":
                    cowList = farm.BredCattleCows;
                    break;
                case "犊牛":
                    cowList = farm.Calfs;
                    break;
                case "泌乳牛":
                    cowList = farm.MilkCows;
                    break;
                case "干奶牛":
                    cowList = farm.DryMilkCows;
                    break;
                case "经产牛未配牛":
                    cowList = farm.UninseminatedMultiParity;
                    break;
                case "经产牛已配未检牛":
                    cowList = farm.InseminatedMultiParity;
                    break;
                case "经产牛已孕牛":
                    cowList = farm.PregnantMultiParity;
                    break;
                case "青年牛未配牛":
                    cowList = farm.UninseminatedNullParity;
                    break;
                case "青年牛已配未检牛":
                    cowList = farm.InseminatedNullParity;
                    break;
                case "青年牛已孕牛":
                    cowList = farm.PregnantNullParity;
                    break;
                default:
                    break;
            }

            return Json(new { Rows = cowList }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 验证显示耳号是否存在
        /// </summary>
        /// <returns></returns>
        public JsonResult CheckDisplayEarNum(string displayEarNum)
        {
            bool result = false;
            if (!string.IsNullOrWhiteSpace(displayEarNum))
            {
                int nID = CowBLL.ConvertDislayEarNumToEarNum(displayEarNum, UserBLL.Instance.CurrentUser.Pasture.ID);
                if (nID != -1)
                {
                    result = true;
                }
            }
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 通过显示耳号取得受孕天数
        /// </summary>
        /// <param name="displayEarNum"></param>
        /// <returns></returns>
        public JsonResult GetDaysOfPregnant(string displayEarNum)
        {
            int earNum = CowBLL.ConvertDislayEarNumToEarNum(displayEarNum, UserBLL.Instance.CurrentUser.Pasture.ID);
            CowInfo cow = new CowInfo(earNum);
            int daysOfPregnant = cow.DaysOfPregnant;
            return Json(new { DaysOfPregnant = daysOfPregnant }, JsonRequestBehavior.AllowGet);
        }
    }
}