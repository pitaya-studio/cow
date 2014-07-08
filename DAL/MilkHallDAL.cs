using DairyCow.DAL.Base;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyCow.DAL
{
    public class MilkHallDAL : BaseDAL
    {
        public DataTable GetMilkHallList()
        {
            DataTable milkHallList = null;
            string sql = string.Format(@"SELECT [ID]
                                            ,[Name]
                                            ,[PastureID]
                                            ,[VacuumPressure]
                                            ,[Pulsation]
                                            ,[CleanupCount]
                                            ,[ModifyTime]
                                        FROM [1mutong].[dbo].[Milk_Hall]");
            milkHallList = dataProvider1mutong.FillDataTable(sql, CommandType.Text);
            return milkHallList;
        }
        public DataTable GetMilkHallByID(int id)
        {
            DataTable milkHallList = null;
            string sql = string.Format(@"SELECT [ID]
                                            ,[Name]
                                            ,[PastureID]
                                            ,[VacuumPressure]
                                            ,[Pulsation]
                                            ,[CleanupCount]
                                            ,[ModifyTime]
                                        FROM [1mutong].[dbo].[Milk_Hall] where ID={0}", id);
            milkHallList = dataProvider1mutong.FillDataTable(sql, CommandType.Text);
            return milkHallList;
        }
        public int UpdateMilkHallInfo(MilkHall milkHall, int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"UPDATE [1mutong].[dbo].[Milk_Hall] set ");
            if (milkHall.VacuumPressure != null)
            {
                sql.Append("[VacuumPressure] = " + milkHall.VacuumPressure + ",");
            }
            if (milkHall.Pulsation != null && milkHall.Pulsation != 0)
            {
                sql.Append("[Pulsation] = " + milkHall.Pulsation + ",");
            }
            if (milkHall.CleanupCount != null && milkHall.CleanupCount != 0)
            {
                sql.Append("[CleanupCount] = " + milkHall.CleanupCount + ",");
            }
            if (milkHall.ModifyTime != null && string.IsNullOrWhiteSpace(milkHall.ModifyTime.ToString()))
            {
                sql.Append("[ModifyTime] = " + milkHall.ModifyTime + ",");
            }
            sql.Append("[Name]='" + milkHall.Name + "' where ID=" + id);
            return dataProvider1mutong.ExecuteNonQuery(sql.ToString(), CommandType.Text);
        }


    }
}
