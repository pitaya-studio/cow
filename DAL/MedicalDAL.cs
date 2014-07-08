using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DairyCow.DAL.Base;
using System.Data;


namespace DairyCow.DAL
{
    /// <summary>
    /// 免疫
    /// </summary>
    public class MedicalDAL:BaseDAL
    {
        public int InsertImmuneRecord(int pastureID,DateTime immuneDate,string vaccine,int earNum,int doctorID)
        {
            string sql = string.Format(@"Insert INTO Medical_Immune 
                                       (PastureID,
                                       ImmuneDate,
                                       Vaccine,
                                       EarNum,
                                       DoctorID) Values({0},{1},[2},{3},{4},{5})",
                                        pastureID, immuneDate.Date, vaccine, earNum, doctorID);
            return dataProvider1mutong.ExecuteNonQuery(sql, CommandType.Text);
        }

        public DataTable GetImmuneTable(int pastureID)
        {
            string sql = string.Format(@"Select PastureID,
                                       ImmuneDate,
                                       Vaccine,
                                       EarNum,
                                       DoctorID
                                        from Medical_Immune
                                        where PastureID={0}", pastureID);
            return dataProvider1mutong.FillDataTable(sql, CommandType.Text);

        }

        public DataTable GetImmuneTable(int pastureID, int earNum)
        {
            string sql = string.Format(@"Select PastureID,
                                       ImmuneDate,
                                       Vaccine,
                                       EarNum,
                                       DoctorID
                                        from Medical_Immune
                                        where PastureID={0} and EarNum={1}", pastureID, earNum);
            return dataProvider1mutong.FillDataTable(sql, CommandType.Text);

        }

        public DataTable GetDiseases()
        {
            string sql = @"SELECT Disease_Id,DiseaseType_Id,DiseaseName,Disease_Code  FROM Medical_DiseaseLibrary";
            return dataProvider1mutong.FillDataTable(sql, CommandType.Text);
        }

        public void InsertCare(int earNum, int diseaseId, string prescription, int doctorID)
        {
            string sql = string.Format(@"insert into Medical_Care(EarNum,Disease_Id,Prescription,DoctorID,Date)
                                         values ('{0}','{1}','{2}','{3}','{4}')",
                                        earNum, diseaseId, prescription, doctorID, DateTime.Now.ToShortDateString());
            dataProvider1mutong.ExecuteNonQuery(sql, CommandType.Text);
        }
    }
}
