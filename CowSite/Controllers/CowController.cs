using DairyCow.BLL;
using DairyCow.Model;
using System.Web.Mvc;

namespace CowSite.Controllers
{
    public class CowController : Controller
    {
        CowBLL bllCow = new CowBLL();

        public ActionResult AssignGroup()
        {
            return View();
        }

        public ActionResult Detail()
        {
            Cow cowItem = bllCow.GetCowInfo(System.Convert.ToInt32(Request.QueryString["earNum"]));
            ViewBag.Cow = cowItem;
            return View();
        }

        /// <summary>
        /// 验证显示耳号是否存在
        /// </summary>
        /// <returns></returns>
        public JsonResult CheckDisplayEarNum(string dislayEarNum)
        {
            bool result = false;
            if (!string.IsNullOrWhiteSpace(dislayEarNum))
            {
                int nID = CowBLL.ConvertDislayEarNumToEarNum(dislayEarNum, UserBLL.Instance.CurrentUser.Pasture.ID);
                if (nID != -1)
                {
                    result = true;
                }
            }
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
    }
}