using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Medical
{
    public class ForbidInseminationController : Controller
    {
        InseminationBLL bllInsemination = new InseminationBLL();
        ForbidInseminationBLL bllForbidInsemination = new ForbidInseminationBLL();

        public ActionResult Edit()
        {
            //ViewBag.EarNum = id;
            return View("~/Views/Medical/ForbidInsemination/Edit.cshtml");
        }

        [HttpPost]
        public ActionResult Forbid(int id)
        {
            // 更新牛的禁配状态
            bllInsemination.ForbidInsemination(id);
            ForbidInsemination forbidInsemination = new ForbidInsemination();
            UpdateModel<ForbidInsemination>(forbidInsemination);
            // 插入牛的禁配信息
            bllForbidInsemination.InsertForbidInseminationInfo(forbidInsemination);
            return RedirectToAction("../Index/List");
        }
    }
}