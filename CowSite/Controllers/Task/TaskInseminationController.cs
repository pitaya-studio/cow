using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Web.Mvc;

namespace CowSite.Controllers.Task
{
    /// <summary>
    /// 发情配种任务处理
    /// </summary>
    public class TaskInseminationController : Controller
    {
        public ActionResult SaveTask()
        {
            try
            {
                string startDate = Request.Form["startDate"];
                string endDate = Request.Form["endDate"];
                string earNum = Request.Form["earNum"];
                string operatorName = Request.Form["operatorName"];
                string knownWay = Request.Form["knownWay"];
                string semenNum = Request.Form["semenNum"];
                string semenCount = Request.Form["semenCount"];
                string desc = Request.Form["desc"];

                Insemination i = new Insemination();
                i.EstrusDate = DateTime.Parse(startDate);
                i.OperateDate = DateTime.Parse(endDate);
                i.EarNum = Convert.ToInt32(earNum);
                i.Operator = operatorName;
                i.EstrusFindType = Convert.ToInt32(knownWay);
                i.SemenNum = semenNum;
                i.InseminationNum = Convert.ToInt32(semenCount);
                i.Description = desc;

                TaskBLL bll = new TaskBLL();
                //bll.CompleteInsemination(i);

            }
            catch (Exception)
            {
                //todo dehua
            }
            return View("~/Views/Task/Index.cshtml");
        }
    }
}