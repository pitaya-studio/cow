using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Feed
{
    public class RemainController : Controller
    {
        RemainRecordBLL bllRemainRecord = new RemainRecordBLL();
        CowGroupBLL bllCowGroup = new CowGroupBLL();
        //
        // GET: /Remain/
        public ActionResult Add(int id)
        {
            ViewBag.ID = id;
            CowGroup cowGroup = bllCowGroup.GetCowGroupInfo(id);
            ViewBag.Name = cowGroup.Name;
            return View("~/Views/Feed/Remain/Add.cshtml");
        }
        [HttpPost]
        public ActionResult Save(int id)
        {
            try
            {
                RemainRecord remainRecord = new RemainRecord();
                UpdateModel<RemainRecord>(remainRecord);
                remainRecord.RecordTime = DateTime.Now;
                remainRecord.CowGroupID = id;
                remainRecord.FormulaID = bllCowGroup.GetFormulaIDByGroupID(id);//需要根据牛群ID获得配方ID

                bllRemainRecord.InsertRemainRecordInfo(remainRecord);
            }
            catch (Exception e)
            {

            }
            return RedirectToAction("../Index/List");
        }
    }
}