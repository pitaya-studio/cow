using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Task
{
    /// <summary>
    /// 复检任务单
    /// </summary>
    public class TaskReInspectionController : Controller
    {
        ReInspectionBLL bllReInspection = new ReInspectionBLL();
        TaskBLL bllTask = new TaskBLL();
        int id = 0;
        public JsonResult LoadTask(string taskID)
        {
            this.id = Convert.ToInt32(taskID);
            DairyTask task = bllTask.GetTaskByID(Convert.ToInt32(taskID));
            var taskData = new
            {
                startTime = task.ArrivalTime,
                earNum = task.EarNum
            };
            return Json(taskData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveTask()
        {
            string startDate = Request.Form["startDate"];
            string endDate = Request.Form["endDate"];
            string earNum = Request.Form["earNum"];
            string operatorName = Request.Form["operatorName"];
            string pregnantStatus = Request.Form["pregnantStatus"];

            ReInspection i = new ReInspection();

            i.OperateDate = DateTime.Parse(endDate);
            i.ReInspectResult = Convert.ToInt32(pregnantStatus);
            i.Operator = operatorName;
            i.EarNum = Convert.ToInt32(earNum);

            DairyTask task = bllTask.GetTaskByID(id);

            //完成初检任务，同时增加初检信息
            bllTask.CompleteReInspection(task, i);

            return View("~/Views/Task/Index.cshtml");
        }
    }
}