﻿using DairyCow.DAL.Base;
using System.Data;

namespace DairyCow.DAL
{
    /// <summary>
    /// 奶牛基本信息数据库访问
    /// </summary>
    public class CowDAL : BaseDAL
    {
        /// <summary>
        /// 所有牛?
        /// </summary>
        /// <returns></returns>
        public DataTable GetCowList(int pastureID)
        {
            DataTable cowList = null;

            string sql = string.Format(@"SELECT D.EarNum, 
                                        D.DisplayEarNum,
                                        D.FarmID, 
                                        D.GroupID, 
                                        D.Gender, 
                                        D.BirthDate, 
                                        D.BirthWeight, 
                                        D.Color, 
                                        D.Status, 
                                        D.IsIll,
                                        G.Name AS GroupName
                                        FROM Base_Cow AS D
                                        LEFT JOIN [Base_CowGroup] AS G
                                        ON D.GroupID = G.ID
                                        WHERE D.FarmID={0}", pastureID);

            cowList = dataProvider1mutong.FillDataTable(sql, CommandType.Text);

            return cowList;
        }

        public DataTable GetCowInfo(int earNum)
        {
            DataTable cowInfo = null;

            string sql = string.Format(@"SELECT D.EarNum, D.DisplayEarNum, D.FarmID, D.GroupID, D.Gender, D.BirthDate,D.IsIll, D.BirthWeight, D.Color, D.Status, G.Name as GroupName 
                                        FROM Base_Cow AS D LEFT JOIN [Base_CowGroup] as G ON D.GroupID = G.ID 
                                        WHERE D.EarNum='{0}'", earNum);

            cowInfo = dataProvider1mutong.FillDataTable(sql, CommandType.Text);

            return cowInfo;
        }     

        /// <summary>
        /// 获取牧场某群牛
        /// </summary>
        /// <param name="farmID">牧场ID</param>
        /// <param name="groupID">牛群ID</param>
        /// <returns></returns>
        public DataTable GetCowListByFarmGroup(int farmID,int groupID)
        {
            DataTable cowList = null;

            string sql = string.Format(@"SELECT D.EarNum, 
                                        D.FarmID, 
                                        D.GroupID, 
                                        D.Gender, 
                                        D.BirthDate, 
                                        D.BirthWeight, 
                                        D.Color, 
                                        D.Status,
                                        D.IsIll, 
                                        G.Name AS GroupName
                                        FROM Base_Cow AS D
                                        LEFT JOIN [Base_CowGroup] AS G
                                        ON D.GroupID = G.ID
                                        WHERE D.FarmID={0} and D.GroupID={1}", farmID,groupID);

            cowList = dataProvider1mutong.FillDataTable(sql, CommandType.Text);

            return cowList;
        }

        /// <summary>
        /// 按繁殖状态获取牛
        /// </summary>
        /// <param name="farmID">牧场ID</param>
        /// <param name="status">繁殖状态，0-6</param>
        /// <returns>牛列表</returns>
        public DataTable GetCowListByFarmStatus(int farmID,int status)
        {
            DataTable cowList = null;

            string sql = string.Format(@"SELECT D.EarNum, 
                                        D.FarmID, 
                                        D.GroupID, 
                                        D.Gender, 
                                        D.BirthDate, 
                                        D.BirthWeight, 
                                        D.Color, 
                                        D.Status, 
                                        D.IsIll,
                                        G.Name AS GroupName
                                        FROM Base_Cow AS D
                                        LEFT JOIN [Base_CowGroup] AS G
                                        ON D.GroupID = G.ID
                                        WHERE D.FarmID={0} and D.Status={1}", farmID, status);

            cowList = dataProvider1mutong.FillDataTable(sql, CommandType.Text);

            return cowList;
        }



        

    


    }
}