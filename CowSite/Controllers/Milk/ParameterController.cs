using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Milk
{
    public class ParameterController : Controller
    {
        MilkHallBLL bllMilkHall = new MilkHallBLL();

        //
        // GET: /Parameter/
        public ActionResult Edit()
        {
            //ViewBag.ID = id;
            //MilkHall milkHall = bllMilkHall.GetMilkHallByID(id);
            //ViewBag.VacuumPressure = milkHall.VacuumPressure;
            //ViewBag.Pulsation = milkHall.Pulsation;
            //ViewBag.CleanupCount = milkHall.CleanupCount;
            //ViewBag.Name = milkHall.Name;
            return View("~/Views/Milk/Hall/Parameters.cshtml");
        }
        [HttpPost]
        public ActionResult Update(int id)
        {
            MilkHall milkHall = new MilkHall();
            UpdateModel<MilkHall>(milkHall);
            MilkHall milkHallExist = bllMilkHall.GetMilkHallByID(id);
            milkHallExist.VacuumPressure = milkHall.VacuumPressure;
            milkHallExist.Pulsation = milkHall.Pulsation;
            milkHallExist.CleanupCount = milkHall.CleanupCount;
            milkHallExist.ModifyTime = DateTime.Now;
            bllMilkHall.UpdateMilkHallInfo(milkHallExist, id);
            return RedirectToAction("../Index/List");
        }
    }
}