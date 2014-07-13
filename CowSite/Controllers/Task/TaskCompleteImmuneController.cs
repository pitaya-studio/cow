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
        public JsonResult LoadTask()
        {
            var taskData = new { doctor = "ss" };
            return Json(taskData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveTask(string id)
        {
            Immune immune = new Immune();
            int PastureID = UserBLL.Instance.CurrentUser.Pasture.ID;
            string ImmuneDate = Request.Form["immuneDate"];
            string Vaccine = Request.Form["immuneType"];
            string EarNum = Request.Form["earNum"];
            string DoctorID = id;

            immune.PastureID = Convert.ToInt32(PastureID);
            immune.ImmuneDate = Convert.ToDateTime(ImmuneDate);
            immune.Vaccine = Vaccine;
            immune.EarNum = Convert.ToInt32(EarNum);
            immune.DoctorID = Convert.ToInt32(DoctorID);

            //增加一头的免疫记录
            bllTask.AddImmuneRecord();
            return View("~/Views/Task/Index.cshtml");
        }
    }
}