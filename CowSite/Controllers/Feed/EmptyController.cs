using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Web.Mvc;

namespace CowSite.Controllers.Feed
{
    public class EmptyController : Controller
    {
        EmptyRecordBLL bllEmptyRecord = new EmptyRecordBLL();
        CowGroupBLL bllCowGroup = new CowGroupBLL();
        
        public ActionResult Add()
        {
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