using DairyCow.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Medical
{
    public class DiagnosesController : Controller
    {
        private MedicalBLL bllMedical = new MedicalBLL();

        /// <summary>
        /// 取得所有疾病
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDiseases()
        {
            return Json(bllMedical.GetDiseases(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 取得所有疾病类型
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDiseasesType()
        {
            return Json(bllMedical.GetDiseasesType(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            return View("~/Views/Medical/Diagnoses/Add.cshtml");
        }
	}
}