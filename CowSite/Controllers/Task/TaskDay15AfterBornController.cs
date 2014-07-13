using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Task
{
    public class TaskDay15AfterBornController : Controller
    {
        public class TaskDay21ToBornController : Controller
        {
            public JsonResult LoadTask(string taskID)
            {
                TaskBLL bll = new TaskBLL();
                DairyTask v;
                v = bll.GetTaskByID(Convert.ToInt32(taskID));

                UserBLL u = new UserBLL();
                User user = u.GetUsers().Find(p => p.ID == v.OperatorID);

                return Json(new
                {
                    EarNum = v.EarNum,
                    ArrivalTime = v.ArrivalTime.ToString("yyyy-MM-dd"),
                    Operator = user.Name
                }, JsonRequestBehavior.AllowGet);
            }

            public JsonResult SaveTask()
            {
                TaskBLL bll = new TaskBLL();
                DairyTask v = bll.GetTaskByID(Convert.ToInt32(Request.Form["id"]));
                v.CompleteTime = DateTime.Parse(Request.Form["endDate"]);

                bll.CompleteDay15AfterBorn(v);
                return Json(new { status = 0 }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}