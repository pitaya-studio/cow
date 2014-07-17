using DairyCow.BLL;
using DairyCow.Model;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CowSite.Controllers.Breed
{
    public class IndexController : Controller
    {
        CowBLL bllCow = new CowBLL();

        public ActionResult Index()
        {
            return View("~/Views/Breed/Index.cshtml");
        }
        
        /// <summary>
        /// 繁殖指标
        /// </summary>
        /// <returns></returns>
        public JsonResult GetBreedIndicant()
        {
            FarmInfo farm = FarmInfo.Instance;

            List<BreedIndicant> lstBreedIndicant = new List<BreedIndicant>();
            // 牧场繁殖指标
            BreedIndicant farmIndicant = new BreedIndicant();
            farmIndicant.Indicant1 = farm.AverageAgeMonthOfFirstBirth;
            farmIndicant.Indicant2 = farm.AverageAgeMonthOfFirstBirthOfParity1;
            farmIndicant.Indicant3 = farm.AverageInseminationDaysAfterBirth;
            farmIndicant.Indicant4 = farm.DaysOfUnpregnant;
            farmIndicant.Indicant5 = farm.DaysFromBirthToSuccessfulInsemination;
            farmIndicant.Indicant6 = farm.AverageParityInterval;
            farmIndicant.Indicant7 = farm.MultiParityCowSuccessPercentageOfFirstInsemination;
            farmIndicant.Indicant8 = farm.NullParityCowSuccessPercentageOfFirstInsemination;
            farmIndicant.Indicant9 = farm.CowSuccessPercentageOfTwiceInsemination;
           lstBreedIndicant.Add(farmIndicant);
            // 牧场繁殖国内参考水平
            BreedIndicant domesticIndicant = new BreedIndicant();
            domesticIndicant.Indicant1 = FarmInfo.REF_AGEMONTH_FIRST_BIRTH_MAX;
            domesticIndicant.Indicant2 = FarmInfo.REF_AGEMONTH_FIRST_BIRTH_MAX;
            domesticIndicant.Indicant3 = FarmInfo.REF_DAYS_FROM_BIRTH_TO_FIRST_HEAT;
            domesticIndicant.Indicant4 = FarmInfo.REF_DAYS_OF_UNPREGNANT;
            domesticIndicant.Indicant5 = FarmInfo.REF_DAYS_FROM_BIRTH_TO_SUCCESSFUL_INSEMINATION_DEMESTIC;
            domesticIndicant.Indicant6 = FarmInfo.REF_AVERAGE_PARITY_INTERVAL_DEMESTIC;
            domesticIndicant.Indicant7 = FarmInfo.REF_MULTIPARITY_COW_SUCCESS_PERCENTAGE_OF_FIRST_INSEMINATION;
            domesticIndicant.Indicant8 = FarmInfo.REF_NULLIPARITY_COW_SUCCESS_PERCENTAGE_OF_FIRST_INSEMINATION;
            domesticIndicant.Indicant9 = FarmInfo.REF_ALL_COW_SUCCESS_PERCENTAGE_OF_TWICE_INSEMINATION;
            lstBreedIndicant.Add(domesticIndicant);
            // 牧场繁殖国外参考水平
            BreedIndicant abroadtIndicant = new BreedIndicant();
            abroadtIndicant.Indicant1 = 0;
            abroadtIndicant.Indicant2 = 0;
            abroadtIndicant.Indicant3 = 0;
            abroadtIndicant.Indicant4 = 0;
            abroadtIndicant.Indicant5 = FarmInfo.REF_DAYS_FROM_BIRTH_TO_SUCCESSFUL_INSEMINATION_ABROAD;
            abroadtIndicant.Indicant6 = FarmInfo.REF_AVERAGE_PARITY_INTERVAL_ABROAD;
            abroadtIndicant.Indicant7 = 0;
            abroadtIndicant.Indicant8 = 0;
            abroadtIndicant.Indicant9 = 0;
            lstBreedIndicant.Add(abroadtIndicant);
            var breedIndicant = new
            {
                Rows = lstBreedIndicant 
            };

            return Json(breedIndicant, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 繁殖饼图
        /// </summary>
        /// <returns></returns>
        public JsonResult GetBreedChart()
        {
            FarmInfo farm = new FarmInfo();

            // 经产牛繁殖状况
            ArrayList arrBreedSummary = new ArrayList();
            arrBreedSummary.Add(new { name = "未配牛", value = farm.CountOfUninseminatedMultiParity });
            arrBreedSummary.Add(new { name = "已配未检牛", value = farm.CountOfInseminatedMultiParity });
            arrBreedSummary.Add(new { name = "已孕头数", value = farm.CountOfPregnantMultiParity });
            // 青年牛繁殖状况
            ArrayList arrParitySummary = new ArrayList();
            arrParitySummary.Add(new { name = "未配牛", value = farm.CountOfUninseminatedNullParity });
            arrParitySummary.Add(new { name = "已配未检牛", value = farm.CountOfInseminatedNullParity });
            arrParitySummary.Add(new { name = "已孕头数", value = farm.CountOfPregnantNullParity });

            return Json(new
            {
                BreedSummary = arrBreedSummary,
                ParitySummary = arrParitySummary
            }, JsonRequestBehavior.AllowGet);
        }
    }

    public class BreedIndicant
    {
        public double Indicant1 { get; set; } //经产牛平均初产月龄
        public double Indicant2 { get; set; } //头胎牛平均初产月龄
        public double Indicant3 { get; set; } //经产牛产后首次发情平均天数(发情间隔)
        public double Indicant4 { get; set; } //经产牛未孕牛空怀天数
        public double Indicant5 { get; set; } //经产牛配准天数
        public double Indicant6 { get; set; } //经产牛胎间距
        public double Indicant7 { get; set; } //经产牛首次配种妊娠率
        public double Indicant8 { get; set; } //青年牛首次配种妊娠率
        public double Indicant9 { get; set; } //总配次<3的配种妊娠率
    }
}