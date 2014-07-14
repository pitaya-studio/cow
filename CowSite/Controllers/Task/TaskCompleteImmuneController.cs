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
        CowBLL bllCow = new CowBLL();
        CowGroupBLL bllCowGroup = new CowGroupBLL();
        int id = 0; //任务ID
        public JsonResult LoadTask(string taskID)
        {
            this.id = Convert.ToInt32(taskID);
            TaskBLL bllTask = new TaskBLL();
            DairyTask task = bllTask.GetTaskByID(Convert.ToInt32(taskID));

            //获得对应牛群的兽医
            Cow cow = bllCow.GetCowInfo(task.EarNum);
            CowGroup cowGroup = bllCowGroup.GetCowGroupInfo(cow.GroupID);
            int doctorID = cowGroup.DoctorID;
            User user = bllUser.GetDefaultDoctor(doctorID);

            var taskData = new
            {
                doctor = user.Role.Name,
                doctorID = doctorID,
                earNum = task.EarNum
            };
            return Json(taskData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveTask()
        {
            try
            {
                Immune immune = new Immune();

                int PastureID = UserBLL.Instance.CurrentUser.Pasture.ID;
                string ImmuneDate = Request.Form["immuneDate"];
                string Vaccine = Request.Form["immuneType"];
                string EarNum = Request.Form["earNum"];
                string DoctorID = Request.Form["doctorID"];

                immune.PastureID = Convert.ToInt32(PastureID);
                immune.ImmuneDate = DateTime.Parse(ImmuneDate);
                immune.Vaccine = Vaccine;
                immune.EarNum = Convert.ToInt32(EarNum);
                immune.DoctorID = Convert.ToInt32(DoctorID);

                //增加一头的免疫记录
                bllTask.AddImmuneRecord(immune);

                //完成免疫任务
                DairyTask task = bllTask.GetTaskByID(id);//To-do please get taskID 
                //task.CompleteTime = DateTime.Now;//fill task data, for this CompleteTime,or use Datetime.Now as default

                bllTask.CompleteImmune(task);
            }
            catch (Exception e)
            {

            }
            return View("~/Views/Task/Index.cshtml");
        }
    }
}