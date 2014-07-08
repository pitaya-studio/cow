using DairyCow.BLL;
using DairyCow.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CowSite.Controllers.Milk
{
    public class IndexController : Controller
    {
        MilkHallBLL bllMilkHall = new MilkHallBLL();

        //
        // GET: /Index/
        public ActionResult List()
        {
            return View("~/Views/Milk/Index/List.cshtml");
        }

        public JsonResult GetMilkHallList()
        {
            List<MilkHall> lstMilkHall = bllMilkHall.GetMilkHallList();
            var milkHallData = new
            {
                Rows = lstMilkHall
            };
            return Json(milkHallData, JsonRequestBehavior.AllowGet);
        }
    }
}