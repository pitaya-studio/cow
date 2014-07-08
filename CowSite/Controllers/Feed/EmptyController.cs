using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Feed
{
    public class EmptyController : Controller
    {
        EmptyRecordBLL bllEmptyRecord = new EmptyRecordBLL();
        CowGroupBLL bllCowGroup = new CowGroupBLL();
        //
        // GET: /Empty/
        public ActionResult Add(int id)
        {
            ViewBag.ID = id;
            CowGroup cowGroup = bllCowGroup.GetCowGroupInfo(id);
            ViewBag.Name = cowGroup.Name;
            return View("~/Views/Feed/Empty/Add.cshtml");
        }

        [HttpPost]
        public ActionResult Save(int id)
        {
            try
            {
                EmptyRecord emptyRecord = new EmptyRecord();
                UpdateModel<EmptyRecord>(emptyRecord);
                emptyRecord.RecordTime = DateTime.Now;
                emptyRecord.CowGroupID = id;
                emptyRecord.FormulaID = bllCowGroup.GetFormulaIDByGroupID(id);//需要根据牛群ID获得配方ID

                bllEmptyRecord.InsertEmptyRecordInfo(emptyRecord);
            }
            catch (Exception e)
            {

            }
            return RedirectToAction("../Index/List");
        }
    }
}