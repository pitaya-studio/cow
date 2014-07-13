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
        public JsonResult LoadTask(string taskID)
        {
            return Json("");
        }

        public ActionResult SaveTask()
        {

            return View("~/Views/Task/Index.cshtml");
        }
    }
}