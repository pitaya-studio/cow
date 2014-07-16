using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DairyCow.DAL.Base;
using System.Data;

namespace DairyCow.DAL
{
    public class DairyParameterDAL:BaseDAL
    {
        public DataTable GetPastureParameters(int pastureID)
        {
            string sql = string.Format(@"SELECT PastureID, 
                                        ParameterName,
                                        ParameterValue, 
                                        CanBeConfiguredByPasture, 
                                        CanBeConfiguredByAdmin, 
                                        Description
                                        FROM Base_Parameter
                                        WHERE PastureID={0}", pastureID);
            return dataProvider1mutong.FillDataTable(sql, CommandType.Text);
        }

        public DataTable GetPlatformParameters()
        {
            return GetPastureParameters(0);
        }

        public int CreateNewPastureParameters(int pastureID)
        {
            int i=0;
            if (GetPastureParameters(pastureID).Rows.Count==0)
            {
                DataTable table = GetPlatformParameters();
                foreach (DataRow item in table.Rows)
                {
                    i=i+InsertParameter(pastureID,item["ParameterName"].ToString(),Convert.ToSingle(item["ParameterValue"]),Convert.ToInt32(item["CanBeConfiguredByPasture"]),Convert.ToInt32(item["CanBeConfiguredByAdmin"]),item["Description"].ToString());
                }
            }
            else
            {
                i = 0;
            }
            return i;
        }

        public int InsertParameter(int pastureID,
                                        string parameterName,
                                        float parameterValue, 
                                        int canBeConfiguredByPasture, 
                                        int canBeConfiguredByAdmin, 
                                        string description)
        {
            string sql = string.Format(@"Insert Into Base_Parameter
                                        (PastureID, 
                                        ParameterName,
                                        ParameterValue, 
                                        CanBeConfiguredByPasture, 
                                        CanBeConfiguredByAdmin, 
                                        Description) VALUES({0},'{1}',{2},{3},{4},'{5}')"
                                        , pastureID, parameterName, parameterValue, 
                                         canBeConfiguredByPasture, 
                                         canBeConfiguredByAdmin, 
                                         description);
            return dataProvider1mutong.ExecuteNonQuery(sql, CommandType.Text);
        }

        public int UpdatePastureParameter(int pastureID,
                                        string parameterName,
                                        float parameterValue)
        {
            string sql = string.Format(@"Update Base_Parameter SET
                                        ParameterValue={2}
                                        WHERE PastureID={0} AND ParameterName='{1}' AND CanBeConfiguredByAdmin=1", pastureID, parameterName, parameterValue);
            return dataProvider1mutong.ExecuteNonQuery(sql, CommandType.Text);
        }

        public int UpdatePlatformParameter(string parameterName,
                                        float parameterValue)
        {
            string sql = string.Format(@"Update Base_Parameter SET
                                        ParameterValue={1} 
                                        WHERE PastureID=0 AND ParameterName={0} AND CanBeConfiguredByPasture=1",  parameterName, parameterValue);
            return dataProvider1mutong.ExecuteNonQuery(sql, CommandType.Text);
        }
    }
}
