using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DairyCow.DAL.Base;
using System.Data;

namespace DairyCow.DAL
{
    public class DryMilkDAL:BaseDAL
    {
        /// <summary>
        /// 获取干奶记录,按日期倒序。
        /// </summary>
        /// <param name="earNum">牛耳号</param>
        /// <returns>干奶记录</returns>
        public DataTable GetCowDryRecords(int earNum)
        {
            DataTable dryRecords = null;
            string sql = string.Format(@"SELECT D.EarNum,D.DryDate,D.DrySituation,D.DryReason,D.OperatorID,U.Name AS OperatorName
                                        FROM Milk_DryEvent AS D Left Join [Auth_User] AS U ON D.OperatorID=U.ID
                                        WHERE D.EarNum={0} ORDER BY D.DryDate DESC", earNum);
            dryRecords = dataProvider1mutong.FillDataTable(sql, CommandType.Text);
            return dryRecords;
        }
        /// <summary>
        /// 获取最新干奶记录
        /// </summary>
        /// <param name="earNum">牛耳号</param>
        /// <returns>干奶记录</returns>
        public DataTable GetLatestCowDryRecords(int earNum)
        {
            DataTable dryRecords = null;
            string sql = string.Format(@"SELECT TOP 1 D.EarNum,D.DryDate,D.DrySituation,D.DryReason,D.OperatorID,U.Name AS OperatorName
                                        FROM Milk_DryEvent AS D Left Join [Auth_User] AS U ON D.OperatorID=U.ID
                                        WHERE D.EarNum={0} ORDER BY D.DryDate DESC", earNum);
            dryRecords = dataProvider1mutong.FillDataTable(sql, CommandType.Text);
            return dryRecords;
        }
    }
}
