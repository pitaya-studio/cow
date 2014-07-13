using DairyCow.BLL;
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