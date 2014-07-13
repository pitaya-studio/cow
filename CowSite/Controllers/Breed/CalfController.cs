using System.Web.Mvc;

namespace CowSite.Controllers.Breed
{
    /// <summary>
    /// 产犊控制器
    /// </summary>
    public class CalfController : Controller
    {
        public ActionResult Add()
        {
            return View("~/Views/Breed/Calf.cshtml");
        }
	}
}