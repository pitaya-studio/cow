using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Feed
{
    public class GradeController : Controller
    {
        GradeBLL bllGrade = new GradeBLL();
        CowBLL bllCow = new CowBLL();
        //
        // GET: /Grade/
        public ActionResult Add(string id)
        {
            ViewBag.EarNum = id;
            return View("~/Views/Feed/Grade/Add.cshtml");
        }

        [HttpPost]
        public ActionResult Save()
        {
            try
            {
                Grade grade = new Grade();
                UpdateModel<Grade>(grade);
                grade.EarNum = CowBLL.ConvertDislayEarNumToEarNum(grade.DisplayEarNum, UserBLL.Instance.CurrentUser.Pasture.ID);
                grade.MeasureDate = DateTime.Now;
                Cow cow = bllCow.GetCowInfo(grade.EarNum);
                if (cow.FarmCode == null)
                {
                    return RedirectToAction("../../Feed/CowGroup/List");
                }
                else
                {
                    bllGrade.InsertGradeInfo(grade);
                }
            }
            catch (Exception e)
            {

            }
            return RedirectToAction("../../Feed/CowGroup/List");
        }
    }
}