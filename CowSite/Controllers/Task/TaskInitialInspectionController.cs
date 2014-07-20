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
    /// 初检
    /// </summary>
    public class TaskInitialInspectionController : Controller
    {
        InitialInspectionBLL bllInitialInspection = new InitialInspectionBLL();
        TaskBLL bllTask = new TaskBLL();
        int id = 0;
        public JsonResult LoadTask(string taskID)
        {
            this.id = Convert.ToInt32(taskID);
            DairyTask task = bllTask.GetTaskByID(Convert.ToInt32(taskID));
            var taskData = new
            {
                startTime = task.ArrivalTime.ToString("yyyy-MM-dd"),
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

            InitialInspection i = new InitialInspection();

            i.OperateDate = DateTime.Parse(endDate);
            i.InspectResult = Convert.ToInt32(pregnantStatus);
            i.Operator = operatorName;
            i.EarNum = Convert.ToInt32(earNum);

            DairyTask task = bllTask.GetTaskByID(id);

            //完成初检任务，同时增加初检信息
            bllTask.CompleteInitialInspection(task, i);

            return View("~/Views/Task/Index.cshtml");
        }
    }
}