using DairyCow.DAL.Base;
using DairyCow.Model;
using System;
using System.Data;

namespace DairyCow.DAL
{
    /// <summary>
    /// 牛群非配DAL
    /// </summary>
    public class CowGroupDAL : BaseDAL
    {
        //获得所有的牛群配种分配信息
        public DataTable GetCowGroupList()
        {
            DataTable cowGroupList = null;
            string sql = string.Format(@"SELECT G.[ID]
                                            ,G.[Name] AS GroupName
                                            ,[PastureID]
                                            ,[FormulaID]
                                            ,[InsemOperatorID] 
											,A.Name AS InsemOperatorName
                                            ,FeedOperatorID
                                            ,DoctorID
                                        FROM [Base_CowGroup] G 
										JOIN [Auth_User] A ON A.ID = G.InsemOperatorID");
            cowGroupList = dataProvider1mutong.FillDataTable(sql, CommandType.Text);
            return cowGroupList;
        }

        /// <summary>
        /// 更新牛群配种员分配信息
        /// </summary>
        /// <param name="cowGroupID">牛群ID</param>
        /// <param name="insemOperatorID">配种员ID</param>
        /// <returns></returns>
        public int UpdateCowGroupInsemOperator(int cowGroupID, int insemOperatorID)
        {
            string sql = string.Format(@"update [Base_CowGroup] set InsemOperatorID ={1} where ID ={0}",cowGroupID,insemOperatorID);
            return dataProvider1mutong.ExecuteNonQuery(sql.ToString(), CommandType.Text);
        }

        /// <summary>
        /// 更新牛群饲养员分配信息
        /// </summary>
        /// <param name="cowGroupID">牛群ID</param>
        /// <param name="feederID">饲养员ID</param>
        /// <returns></returns>
        public int UpdateCowFeeder(int cowGroupID, int feederID)
        {
            string sql = string.Format(@"update [Base_CowGroup] set FeedOperatorID ={1} where ID ={0}", cowGroupID, feederID);
            return dataProvider1mutong.ExecuteNonQuery(sql.ToString(), CommandType.Text);

        }

        /// <summary>
        /// 更新牛群兽医分配信息
        /// </summary>
        /// <param name="cowGroupID">牛群ID</param>
        /// <param name="doctorID">兽医ID</param>
        /// <returns></returns>
        public int UpdateCowGroupDoctor(int cowGroupID, int doctorID)
        {
            string sql = string.Format(@"update [Base_CowGroup] set DoctorID ={1} where ID ={0}", cowGroupID, doctorID);
            return dataProvider1mutong.ExecuteNonQuery(sql.ToString(), CommandType.Text);
        }


        /// <summary>
        /// 更新牛群信息
        /// </summary>
        /// <returns></returns>
        public int UpdateCowGroupInfo(CowGroup group)
        {
            string sql = string.Format(@"UPDATE [Base_CowGroup]
                                           SET [Name] = '{0}'
                                              ,[PastureID] = {1}
                                              ,[FormulaID] = {2}
                                              ,[Type] = {3}
                                              ,[Description] = '{4}'
                                        WHERE ID = {5}", group.Name, group.PastureID, group.FormulaID, group.Type, group.Description, group.ID);
            return dataProvider1mutong.ExecuteNonQuery(sql.ToString(), CommandType.Text);
        }

        public DataTable GetCowGroupInfo()
        {
            DataTable cowGroup = null;

            string sql = string.Format(@"SELECT G.[ID],G.[NAME],G.[FORMULAID],G.TYPE,P.NAME AS PastureName,G.Description,F.Name AS FormulaName
                                        FROM [DBO].[BASE_COWGROUP] AS G
										LEFT JOIN [DBO].[BASE_PASTURE] AS P
										ON P.ID = G.PASTUREID
										LEFT JOIN [DBO].[FEED_FORMULA] F
										ON F.ID = G.FORMULAID");

            cowGroup = dataProvider1mutong.FillDataTable(sql, CommandType.Text);

            return cowGroup;
        }

        //根据牛群ID获得配方ID
        public int GetFormulaIDByGroupID(int id)
        {
            int formulaID = 0;
            string sql = string.Format(@"select top(1) FodderFormulaID from [1mutong].[dbo].[Base_CowGroup] where ID = {0}", id);
            formulaID = Convert.ToInt32(dataProvider1mutong.ExecuteScalar(sql, CommandType.Text));
            return formulaID;
        }

        public DataTable GetCowGroupInfo(int id)
        {
            DataTable cowGroup = null;
            string sql = string.Format(@"SELECT [ID]
                                            ,[Name]
                                            ,[PastureID]
                                            ,[FormulaID]
                                            ,[Type]
                                            ,[InsemOperatorID]
                                            ,[DoctorID]
                                            ,[Description]
                                        FROM [Base_CowGroup] where ID = {0}", id);
            cowGroup = dataProvider1mutong.FillDataTable(sql, CommandType.Text);
            return cowGroup;
        }

        public int GetCowCount(int groupID)
        {
            DataTable DT = null;
            string sql = string.Format(@"SELECT COUNT(*)
                                        FROM Base_CowGroup AS G LEFT JOIN Base_Cow AS C ON G.ID = C.GroupID
                                        WHERE G.ID = '{0}'", groupID);
            DT = dataProvider1mutong.FillDataTable(sql, CommandType.Text);
            return Convert.ToInt32(DT.Rows[0].ItemArray[0]);
        }

        public DataTable GetCowCountInHouse(int groupID)
        {
            DataTable DT = null;
            string sql = string.Format(@"SELECT H.Name, count(*) AS CowCount
                                      FROM Base_Cow AS C left join Base_CowHouse as H on C.HouseID = H.ID
                                      WHERE C.GROUPID = '{0}'
                                      GROUP BY H.Name", groupID);
            DT = dataProvider1mutong.FillDataTable(sql, CommandType.Text);
            return DT;
        }
    }
}
