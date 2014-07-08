using DairyCow.BLL;
using DairyCow.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CowSite.Controllers.Breed
{
    public class IndexController : Controller
    {
        CowBLL bllCow = new CowBLL();

        public ActionResult List()
        {
            return View("~/Views/Breed/Index/List.cshtml");
        }

        public JsonResult GetCowList()
        {
            List<Cow> lstCow = bllCow.GetCowList();
            var cowData = new
            {
                Rows = lstCow 
            };
            return Json(cowData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}