﻿using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Web.Mvc;

namespace CowSite.Controllers.Feed
{
    public class RemainController : Controller
    {
        RemainRecordBLL bllRemainRecord = new RemainRecordBLL();
        CowGroupBLL bllCowGroup = new CowGroupBLL();

        public ActionResult Add()
        {
            return View("~/Views/Feed/Remain/Add.cshtml");
        }

        [HttpPost]
        public ActionResult Save()
        {
            try
            {
                string cowGroupID = Request.Form["cowGroupName"];
                string remainQuantity = Request.Form["reQuantity"];

                RemainRecord remainRecord = new RemainRecord();
                remainRecord.CowGroupID = Convert.ToInt32(cowGroupID);
                remainRecord.FormulaID = bllCowGroup.GetFormulaIDByGroupID(Convert.ToInt32(cowGroupID));//需要根据牛群ID获得配方ID
                remainRecord.RecordUserID = UserBLL.Instance.CurrentUser.ID;
                remainRecord.RecordTime = DateTime.Now;
                float s;
                float.TryParse(remainQuantity, out s);
                remainRecord.RemainQuantity = s;

                bllRemainRecord.InsertRemainRecordInfo(remainRecord);
            }
            catch (Exception e)
            {

            }
            return RedirectToAction("../../Feed/CowGroup/List");
        }
    }
}