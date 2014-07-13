using System.Web.Mvc;

namespace CowSite.Controllers.Task
{
    /// <summary>
    /// 发情配种任务处理
    /// </summary>
    public class TaskInseminationController : Controller
    {
        public JsonResult LoadTask(string taskID)
        {
            return Json(new { Instruction = "请观测牛群发情状况，并给发情牛配种。", EarNum = "11111" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveTask()
        {
            string op = Request.Form["operatorName"];
            
            return View("~/Views/Task/Index.cshtml");
        }
    }
}