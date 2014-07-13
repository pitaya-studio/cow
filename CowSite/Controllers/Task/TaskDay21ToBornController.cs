using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Task
{
    public class TaskDay21ToBornController : Controller
    {
        public JsonResult LoadTask(string taskID)
        {
            TaskBLL bll = new TaskBLL();

            DairyTask v = bll.GetTaskByID(Convert.ToInt32(taskID));

            UserBLL u = new UserBLL();
            User user = u.GetUsers().Find(p => p.ID == v.OperatorID);

            return Json(new { EarNum=v.EarNum,
                ArrivalTime=v.ArrivalTime.ToString("yyyy-MM-dd"),
                Operator = user.Name
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveTask()
        {
            string op = Request.Form["operatorName"];

            return Json(new { status = 0 }, JsonRequestBehavior.AllowGet);
        }
	}
}
