using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Milk
{
    public class DailyMilkYieldController : Controller
    {
        MilkRecordBLL bllMilkRecord = new MilkRecordBLL();
        //
        // GET: /DailyMilkYield/
        public ActionResult Add()
        {
            return View("~/Views/Milk/DailyMilkYield/Add.cshtml");
        }

        public ActionResult Save()
        {
            MilkSale milkSale = new MilkSale();
            UpdateModel<MilkSale>(milkSale);
            bllMilkRecord.InsertMilkSale(milkSale);
            //有几个字段未赋值
            return RedirectToAction("../Index/List");
        }
    }
}