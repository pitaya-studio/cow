using Common;
using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CowSite.Controllers.Feed
{
    public class CowGroupController : Controller
    {
        CowGroupBLL bllCowGroup = new CowGroupBLL();

        public JsonResult GetCowGroupInfo()
        {
            List<CowGroup> lstCowGroup = bllCowGroup.GetCowGroupInfo();
            var cowGroupData = new
            {
                Rows = lstCowGroup
            };
            return Json(cowGroupData, JsonRequestBehavior.AllowGet);
        }

        //用于select绑定
        public JsonResult GetCowGroupList()
        {
            List<CowGroup> lstCowGroup = bllCowGroup.GetCowGroupInfo();
            return Json(lstCowGroup, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRemindCows()
        {
            List<CowInfo> cows;
            FarmInfo fi = new FarmInfo();
            cows = fi.GetNeedRegroupingCows();

            return Json(cows, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List()
        {
            ViewBag.CowGroupID = Request.QueryString["id"];
            return View("~/Views/CowGroup/List.cshtml");
        }

        //弹出新增牛群详细对话框
        public ActionResult AddCowGroup()
        {
            return View("~/Views/CowGroup/Add.cshtml");
        }

        public ActionResult Remind()
        {
            return View("~/Views/CowGroup/Remind.cshtml");
        }

        public ActionResult Assign()
        {
            return View("~/Views/CowGroup/Assign.cshtml");
        }

        public JsonResult GetCowGroupItem(string id)
        {
            return Json(this.bllCowGroup.GetCowGroupInfo(Convert.ToInt32(id)), JsonRequestBehavior.AllowGet);
        }
        //删除牛群
        public JsonResult Delete(string id)
        {
            int i = bllCowGroup.DeleteCowGroup(Convert.ToInt32(id));
            if (i == 0)
            {
                var msg = "牛群存在牛不能删除！";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var msg = "牛群删除成功！";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }
        //增加牛群
        public JsonResult Add()
        {
            CowGroup group = new CowGroup();
            group.PastureID = UserBLL.Instance.CurrentUser.Pasture.ID;
            group.Name = Request.Form["Name"];
            group.TypeNum = Convert.ToInt32(Request.Form["Type"]);
            group.Description = Request.Form["Description"];
            bllCowGroup.AddCowGroupWithBasicInfo(group);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
    }
}