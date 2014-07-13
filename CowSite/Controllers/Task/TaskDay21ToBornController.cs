using DairyCow.BLL;
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
            
            //var v = TaskBLL

            return Json(new { 
                Instruction = "请观测牛群发情状况，并给发情牛配种。", 
                EarNum = "11111" 
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveTask()
        {
            string op = Request.Form["operatorName"];

            return Json(new { status = 0 }, JsonRequestBehavior.AllowGet);
        }
	}
}