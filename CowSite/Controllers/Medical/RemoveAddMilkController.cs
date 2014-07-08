﻿using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Medical
{
    public class RemoveAddMilkController : Controller
    {
        RemoveAddMilkBLL bllRemoveAddMilk = new RemoveAddMilkBLL();
        //
        // GET: /RemoveAddMilk/
        public ActionResult Add()
        {
            return View("~/Views/Medical/MilkBreast/Add.cshtml");
        }

        [HttpPost]
        public ActionResult Save()
        {
            RemoveAddMilk removeAddMilk = new RemoveAddMilk();
            UpdateModel<RemoveAddMilk>(removeAddMilk);
            bllRemoveAddMilk.InsertRemoveAddMilkInfo(removeAddMilk);
            return RedirectToAction("../Index/List");
        }
    }
}