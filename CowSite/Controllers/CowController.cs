using Common;
using DairyCow.BLL;
using DairyCow.Model;
using System.Collections.Generic;
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
	}
}