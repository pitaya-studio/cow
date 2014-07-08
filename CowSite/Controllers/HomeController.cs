using CowSite.Base;
using DairyCow.BLL;
using DairyCow.Model;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CowSite.Controllers
{
    public class HomeController : Controller
    {
        TaskBLL task = new TaskBLL();
        FarmInfo farm = new FarmInfo();

        public ActionResult Index()
        {
            ViewBag.PastureID = UserBLL.Instance.CurrentUser.Pasture.ID;
            return View();
        }

        /// <summary>
        /// 牛群结构图
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCowGroupSummary(int pastureID)
        {
            // 牛群整体结构
            ArrayList arrCowSummary = new ArrayList();
            arrCowSummary.Add(new { name = "经产牛", value = farm.CountOfMultiParity });
            arrCowSummary.Add(new { name = "青年牛", value =farm.CountOfNullParity });
            arrCowSummary.Add(new { name = "育成牛", value = farm.CountOfBredCattle });
            arrCowSummary.Add(new { name = "犊牛", value = farm.CountOfCalf });
            // 牛群泌乳状态
            ArrayList arrMilkCowSummary = new ArrayList();
            arrMilkCowSummary.Add(new { name = "泌乳牛", value = farm.CountOfMilkCows });
            arrMilkCowSummary.Add(new { name = "干奶牛", value = farm.CountOfDryMilkCows });
            // 经产牛繁殖状况
            ArrayList arrBreedSummary = new ArrayList();
            arrBreedSummary.Add(new { name = "未配牛", value = farm.CountOfUninseminatedMultiParity });
            arrBreedSummary.Add(new { name = "已配未检牛", value=  farm.CountOfInseminatedMultiParity });
            arrBreedSummary.Add(new { name = "已孕头数", value = farm.CountOfPregnantMultiParity });
            // 经产牛胎次状况
            ArrayList arrParitySummary = new ArrayList();
            arrParitySummary.Add(new { name = "1胎牛", value = farm.CountOfParity1Cows });
            arrParitySummary.Add(new { name = "2胎牛", value = farm.CountOfParity2Cows });
            arrParitySummary.Add(new { name = "3胎及以上的牛", value =farm.CountOfParity3AndMoreCows });

            return Json(new 
            {
                CowSummary = arrCowSummary,
                MilkCowSummary = arrMilkCowSummary,
                BreedSummary = arrBreedSummary,
                ParitySummary = arrParitySummary
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetToDoList()
        {
            List<DairyTask> lstTask = task.GetRecentUnfinishedTaskList(UserBLL.Instance.CurrentUser.ID, UserBLL.Instance.CurrentUser.Pasture.ID);

            return Json(new
            {
                ToDoList = lstTask
            }, JsonRequestBehavior.AllowGet);
        }
    }
}