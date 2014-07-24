using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Milk
{
    public class MilkabilityCheckController : Controller
    {
        IndividualProdcutionBLL bllIndividual = new IndividualProdcutionBLL();
        public ActionResult Add()
        {
            return View("~/Views/Milk/MilkabilityCheck/Add.cshtml");
        }
        public JsonResult AddMilkAbility(string earNum, string date, string ability, string round)
        {
            IndividualProdcution production = new IndividualProdcution();
            production.EarNum = CowBLL.ConvertDislayEarNumToEarNum(earNum, UserBLL.Instance.CurrentUser.Pasture.ID);
            production.MilkDate = Convert.ToDateTime(date);
            production.MilkWeight = float.Parse(ability);
            production.Round = round;

            bllIndividual.InsertIndividualProdcution(production);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
    }
}