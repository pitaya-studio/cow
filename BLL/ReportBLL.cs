using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DairyCow.Model;
using DairyCow.DAL;

namespace DairyCow.BLL
{
    public class ReportBLL
    {

    }

    public class DailyReportBLL
    {
        FarmInfo myFarm;
        private int pastureID;
        public DailyReportBLL(int pastureID)
        {
            myFarm = new FarmInfo(pastureID);
            this.pastureID = pastureID;
        }
        /// <summary>
        /// 插入一条日报
        /// </summary>
        /// <returns></returns>
        public int InsertDailyReport()
        {
            int temp = 0;
            DailyReport myReport = new DailyReport();
            myReport.PastureID = this.pastureID;
            myReport.ReportDate = DateTime.Now.Date;
            //牛群结构
            myReport.CalfNumber = myFarm.CountOfCalf;
            myReport.BredCattleNumber = myFarm.CountOfBredCattle;
            myReport.MultiParityNumber = myFarm.CountOfMultiParity;
            myReport.NullParityNumber = myFarm.CountOfNullParity;
            myReport.MilkCowNumber = myFarm.CountOfMilkCows;
            myReport.DryCowNumber = myFarm.CountOfDryMilkCows;

            ReportDAL dal = new ReportDAL();
            temp = dal.InsertDailyReport(myReport.PastureID, myReport.ReportDate, myReport.MilkCowNumber, myReport.DryCowNumber, myReport.MultiParityNumber, myReport.NullParityNumber, myReport.CalfNumber, myReport.BredCattleNumber);

            
            ////产犊
            //myReport.CalvingNumber = FarmInfo.GetSumCalving(this.pastureID, myReport.ReportDate);
            //myReport.MaleCalfNumber = FarmInfo.GetSumMaleCalf(this.pastureID, myReport.ReportDate);
            //myReport.FemaleCalfNumber = FarmInfo.GetSumFemaleCalf(this.pastureID, myReport.ReportDate);

            ////产奶
            //MilkRecord milk=new MilkRecord(this.pastureID,myReport.ReportDate);
            //myReport.SaleMilk = milk.TotalMilkSale;
            //myReport.AbnormalSaleMilk = milk.OtherMilkRecord.AbnormalSaleMilk;
            //myReport.MilkForCalf = milk.OtherMilkRecord.MilkForCalf;
            //myReport.BadMilk = milk.OtherMilkRecord.BadMilk;
            //myReport.LeftMilk = milk.OtherMilkRecord.LeftMilk;

            return temp;

        }

        public DailyReport GetDailyReport(int pastureID,DateTime date)
        {
            DailyReport myReport ;
            ReportDAL dal = new ReportDAL();
            DataTable table = dal.GetDailyReportTable(pastureID, date.Date);
            if (table.Rows.Count==1)
            {
                myReport = WrapDailyReportItem(table.Rows[0]);
                myReport.PastureID = pastureID;

                //产犊
                myReport.CalvingNumber = FarmInfo.GetSumCalving(this.pastureID, myReport.ReportDate);
                myReport.MaleCalfNumber = FarmInfo.GetSumMaleCalf(this.pastureID, myReport.ReportDate);
                myReport.FemaleCalfNumber = FarmInfo.GetSumFemaleCalf(this.pastureID, myReport.ReportDate);

                //产奶
                MilkRecord milk = new MilkRecord(this.pastureID, myReport.ReportDate);
                myReport.SaleMilk = milk.TotalMilkSale;
                myReport.AbnormalSaleMilk = milk.OtherMilkRecord.AbnormalSaleMilk;
                myReport.MilkForCalf = milk.OtherMilkRecord.MilkForCalf;
                myReport.BadMilk = milk.OtherMilkRecord.BadMilk;
                myReport.LeftMilk = milk.OtherMilkRecord.LeftMilk;

            }
            else
            {
                myReport = null;
            }
            return myReport;
        }

        public List<DailyReport> GetDailyReport(int pastureID, DateTime startDate,DateTime endDate)
        {
            List<DailyReport> list = new List<DailyReport>();
            ReportDAL dal = new ReportDAL();
            DataTable table = dal.GetDailyReportTable(pastureID, startDate.Date,endDate.Date);
            foreach (DataRow item in table.Rows)
            {
                DailyReport myReport = WrapDailyReportItem(item);
                myReport.PastureID = pastureID;

                //产犊
                myReport.CalvingNumber = FarmInfo.GetSumCalving(this.pastureID, myReport.ReportDate);
                myReport.MaleCalfNumber = FarmInfo.GetSumMaleCalf(this.pastureID, myReport.ReportDate);
                myReport.FemaleCalfNumber = FarmInfo.GetSumFemaleCalf(this.pastureID, myReport.ReportDate);

                //产奶
                MilkRecord milk = new MilkRecord(this.pastureID, myReport.ReportDate);
                myReport.SaleMilk = milk.TotalMilkSale;
                myReport.AbnormalSaleMilk = milk.OtherMilkRecord.AbnormalSaleMilk;
                myReport.MilkForCalf = milk.OtherMilkRecord.MilkForCalf;
                myReport.BadMilk = milk.OtherMilkRecord.BadMilk;
                myReport.LeftMilk = milk.OtherMilkRecord.LeftMilk;

                list.Add(myReport);
            }
            return list;
        }


        public DailyReport WrapDailyReportItem(DataRow row)
        {
            DailyReport report = new DailyReport();
            report.CalfNumber = Convert.ToInt32(row["CalfNumber"]);
            report.BredCattleNumber = Convert.ToInt32(row["BredCattleNumber"]);
            report.NullParityNumber = Convert.ToInt32(row["NullParityNumber"]);
            report.MultiParityNumber = Convert.ToInt32(row["MultiParityNumber"]);
            report.MilkCowNumber = Convert.ToInt32(row["MilkCowNumber"]);
            report.DryCowNumber = Convert.ToInt32(row["DryCowNumber"]);
            report.ReportDate = Convert.ToDateTime(row["ReportDate"]);
            return report;
        }
    
    }
}
