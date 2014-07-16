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

        public ActionResult List()
        {
            ViewBag.CowGroupID = Request.QueryString["id"];
            return View("~/Views/CowGroup/List.cshtml");
        }

        public ActionResult ModifyCowGroup()
        {
            ViewBag.CowGroupID = Request.QueryString["id"];
            return View("~/Views/CowGroup/ModifyCowGroup.cshtml");
        }

        public ActionResult Remind()
        {
            return View("~/Views/CowGroup/Remind.cshtml");
        }

        public JsonResult GetCowGroupItem(string id)
        {
            return Json(this.bllCowGroup.GetCowGroupInfo(Convert.ToInt32(id)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCowGroupInfo()
        {
            CowGroup cowGroup = new CowGroup();
            UpdateModel<CowGroup>(cowGroup);
            return Json(this.bllCowGroup.UpdateCowGroupInfo(cowGroup), JsonRequestBehavior.AllowGet);
        }
	}
}