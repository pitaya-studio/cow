﻿using DairyCow.BLL;
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

        public ActionResult CowList()
        {
            ViewBag.CowType = Request.QueryString["cowType"];
            return View("~/Views/Cow/List.cshtml");
        }

        public JsonResult GetCowList(string cowType)
        {
            FarmInfo farm = FarmInfo.Instance;

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
                default:
                    break;
            }

            return Json(new { Rows = cowList }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCowInfo(string displayEarNum)
        {
            Cow cowItem = bllCow.GetCowInfo(UserBLL.Instance.CurrentUser.Pasture.ID, displayEarNum);
            return Json(new { Cow = cowItem }, JsonRequestBehavior.AllowGet);
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