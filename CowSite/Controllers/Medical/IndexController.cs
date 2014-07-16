using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Medical
{
    /// <summary>
    /// 繁殖首页处理
    /// </summary>
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/Medical/Index.cshtml");
        }        
	}
}