using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DairyCow.Model;
using DairyCow.DAL.Base;

namespace DairyCow.DAL
{
    public class HouseDAL:BaseDAL
    {
        /// <summary>
        /// 获取牧场所有牛舍
        /// </summary>
        /// <param name="pastureID"></param>
        /// <returns></returns>
        public DataTable GetHouseTable(int pastureID)
        {
            string sql = string.Format(@"SELECT [ID]
                                          ,[Name]
                                          ,[GroupID]
                                          ,[PastureID]
                                      FROM [Base_CowHouse]
                                        where PastureID={0}", pastureID);
            return dataProvider1mutong.FillDataTable(sql, CommandType.Text);

        }

        /// <summary>
        /// 插入牛舍
        /// </summary>
        /// <param name="name"></param>
        /// <param name="groupID"></param>
        /// <param name="pastureID"></param>
        /// <returns></returns>
        public int InsertHouse(string name,int groupID,int pastureID)
        {
            string sql = string.Format(@"Insert [Base_CowHouse] 
                                       ([Name]
                                          ,[GroupID]
                                          ,[PastureID]) Values('{0}',{1},[2})",
                                        name, groupID, pastureID);
            return dataProvider1mutong.ExecuteNonQuery(sql, CommandType.Text);
        }
        /// <summary>
        /// 插入未分配牛群的牛舍
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pastureID"></param>
        /// <returns></returns>
        public int InsertHouse(string name, int pastureID)
        {
            
            return InsertHouse(name,0,pastureID);
        }
    }
}
