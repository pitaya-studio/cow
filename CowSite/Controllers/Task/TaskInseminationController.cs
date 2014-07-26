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
        TaskBLL bllTask = new TaskBLL();
        InseminationBLL bllInsemination = new InseminationBLL();
        public ActionResult SaveTask()
        {
            try
            {
                string displayEarNum = Request.Form["DisplayEarNum"];
                string startDate = Request.Form["start"];
                string endDate = Request.Form["end"];
                string operatorID = Request.Form["operatorName"];
                string knownWay = Request.Form["knownWay"];
                string semenNum = Request.Form["semNum"];
                string semenCount = Request.Form["semCount"];
                string desc = Request.Form["description"];

                Insemination i = new Insemination();
                i.EstrusDate = DateTime.Parse(startDate);
                i.OperateDate = DateTime.Parse(endDate);
                i.EarNum = CowBLL.ConvertDislayEarNumToEarNum(displayEarNum, UserBLL.Instance.CurrentUser.Pasture.ID);
                i.operatorID = Convert.ToInt32(operatorID);
                i.EstrusFindType = Convert.ToInt32(knownWay);
                i.SemenNum = semenNum;
                i.InseminationNum = Convert.ToInt32(semenCount);
                i.Description = desc;

                bllInsemination.InsertInseminationInfo(i);
                bllTask.CompleteInsemination(i);

            }
            catch (Exception)
            {
                //todo dehua
            }
            return View("~/Views/Task/Index.cshtml");
        }
    }
}