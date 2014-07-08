using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CowSite.Controllers.Feed
{
    public class IndexController : Controller
    {
        CowGroupBLL bllCowGroup = new CowGroupBLL();

        //
        // GET: /Index/
        public ActionResult List()
        {
            return View("~/Views/Feed/Index/List.cshtml");
        }
	}
}