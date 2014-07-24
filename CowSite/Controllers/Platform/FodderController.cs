using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DairyCow.Model;
using DairyCow.BLL;

namespace CowSite.Controllers.Platform
{
    /// <summary>
    /// 平台-饲料管理
    /// </summary>
    public class FodderController : Controller
    {
        public ActionResult List()
        {
            return View("~/Views/Platform/Fodder/List.cshtml");
        }

        public JsonResult AddFodder()
        {
            FodderBLL fodderBLL = new FodderBLL();
            Fodder f = new Fodder();
            f.Name = Request.Form["fodderName"].ToString();
            f.Description = Request.Form["description"].ToString();
            f.RefPrice = Convert.ToDouble(Request.Form["price"]);

            f.DM = Convert.ToDouble(Request.Form["DM"]);
            f.NND = Convert.ToDouble(Request.Form["NND"]);
            f.Ca = Convert.ToDouble(Request.Form["Ca"]);
            f.P = Convert.ToDouble(Request.Form["P"]);
            f.CP = Convert.ToDouble(Request.Form["CP"]);
            f.CF = Convert.ToDouble(Request.Form["CF"]);
            f.Fat = Convert.ToDouble(Request.Form["Fat"]);
            f.NFE = Convert.ToDouble(Request.Form["NFE"]);
            f.ASH = Convert.ToDouble(Request.Form["ASH"]);
            f.NDF = Convert.ToDouble(Request.Form["NDF"]);
            f.ADF = Convert.ToDouble(Request.Form["ADF"]);
            f.NPP = Convert.ToDouble(Request.Form["NPP"]);
            f.Arg = Convert.ToDouble(Request.Form["Arg"]);
            f.His = Convert.ToDouble(Request.Form["His"]);
            f.Ile = Convert.ToDouble(Request.Form["Ile"]);
            f.Leu = Convert.ToDouble(Request.Form["Leu"]);
            f.Lys = Convert.ToDouble(Request.Form["Lys"]);
            f.Met = Convert.ToDouble(Request.Form["Met"]);
            f.Cys = Convert.ToDouble(Request.Form["Cys"]);
            f.Phe = Convert.ToDouble(Request.Form["Phe"]);
            f.Tyr = Convert.ToDouble(Request.Form["Tyr"]);
            f.Thr = Convert.ToDouble(Request.Form["Thr"]);
            f.Trp = Convert.ToDouble(Request.Form["Trp"]);
            f.Val = Convert.ToDouble(Request.Form["Val"]);
            f.Na = Convert.ToDouble(Request.Form["Na"]);
            f.Cl = Convert.ToDouble(Request.Form["Cl"]);
            f.Mg = Convert.ToDouble(Request.Form["Mg"]);
            f.K = Convert.ToDouble(Request.Form["K"]);
            f.Fe = Convert.ToDouble(Request.Form["Fe"]);
            f.Cu = Convert.ToDouble(Request.Form["Cu"]);
            f.Mn = Convert.ToDouble(Request.Form["Mn"]);
            f.Zn = Convert.ToDouble(Request.Form["Zn"]);
            f.Se = Convert.ToDouble(Request.Form["Se"]);

            int temp = fodderBLL.InsertFodder(f);

            return Json(new { Result = temp });

        }
	}
}