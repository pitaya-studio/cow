using DairyCow.BLL;
using DairyCow.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CowSite.Controllers.Breed
{
    public class UnForbidInseminationController : Controller
    {
        CowBLL bllCow = new CowBLL();
        InseminationBLL bllInsemination = new InseminationBLL();
        UnForbidInseminationBLL bllUnforbidInsemination = new UnForbidInseminationBLL();

        public ActionResult Edit()
        {
            //ViewBag.EarNum = id;
            return View("~/Views/Breed/UnForbidInsemination/Edit.cshtml");
        }

        [HttpPost]
        public ActionResult UnForbid(int id)
        {
            bllInsemination.UnDoForbidInsemination(id);
            UnForbidInsemination unForbidInsemination = new UnForbidInsemination();
            UpdateModel<UnForbidInsemination>(unForbidInsemination);
            //插入牛的解禁信息
            bllUnforbidInsemination.InsertUnForbidInseminationInfo(unForbidInsemination);
            return RedirectToAction("../Index/List");
        }

        /// <summary>
        /// 取得所有禁配状态的牛
        /// </summary>
        /// <returns></returns>
        public JsonResult GetForbidCowList()
        {
            List<Cow> lstCow = bllCow.GetCowList(UserBLL.Instance.CurrentUser.Pasture.ID).FindAll(p => p.Status == "禁配");
            return Json(lstCow, JsonRequestBehavior.AllowGet);
        }
    }
}