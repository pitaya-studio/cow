using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Feed
{
    /// <summary>
    /// 牛舍维护
    /// </summary>
    public class CowHouseController : Controller
    {
        HouseBLL bllHouse = new HouseBLL();

        public JsonResult GetCowHouseInfo()
        {
            int pastureID = Convert.ToInt32(UserBLL.Instance.CurrentUser.Pasture.ID);
            List<House> lstHouse = bllHouse.GetHouseList(pastureID);
            var cowHouseData = new
            {
                Rows = lstHouse
            };
            return Json(cowHouseData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult List()
        {
            return View("~/Views/Feed/CowHouse/List.cshtml");
        }
    }
}