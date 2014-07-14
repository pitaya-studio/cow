using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Task
{
    public class TaskCompleteImmuneController : Controller
    {
        /// <summary>
        /// 免疫
        /// </summary>
        /// <param name="taskID"></param>
        /// <returns></returns>
        TaskBLL bllTask = new TaskBLL();
        UserBLL bllUser = new UserBLL();
        public JsonResult LoadTask()
        {
            User user = new User();
            user = bllUser.GetDefaultDoctor();
            var taskData = new { doctor = user.Role.Name, doctorID = user.Role.ID };
            return Json(taskData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveTask()
        {
            Immune immune = new Immune();
            int PastureID = UserBLL.Instance.CurrentUser.Pasture.ID;
            string ImmuneDate = Request.Form["immuneDate"];
            string Vaccine = Request.Form["immuneType"];
            string EarNum = Request.Form["earNum"];
            string DoctorID = Request.Form["doctorID"];

            immune.PastureID = Convert.ToInt32(PastureID);
            immune.ImmuneDate = Convert.ToDateTime(ImmuneDate);
            immune.Vaccine = Vaccine;
            immune.EarNum = Convert.ToInt32(EarNum);
            immune.DoctorID = Convert.ToInt32(DoctorID);

            //增加一头的免疫记录
            bllTask.AddImmuneRecord(immune);
            //完成免疫任务
            int taskID = 1;//To-do please get taskID 
            DairyTask task = bllTask.GetTaskByID(taskID);
            //fill task data, for this CompleteTime,or use Datetime.Now as default
            bllTask.CompleteImmune(task);

            return View("~/Views/Task/Index.cshtml");
        }
    }
}