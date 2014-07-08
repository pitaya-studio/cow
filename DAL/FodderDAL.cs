using DairyCow.DAL.Base;
using System.Data;

namespace DairyCow.DAL
{
    public class FodderDAL : BaseDAL
    {
        public DataTable GetFodder(int pastureID)
        {
            DataTable fodderList = null;

            string sql = string.Format(@"SELECT *
                                FROM [Feed_PastureFodder]
                                left join Feed_Fodder on Feed_Fodder.ID = Feed_PastureFodder.SysFodderID
                                where PastureID = {0} and IsCurrent = 1", pastureID);

            fodderList = dataProvider1mutong.FillDataTable(sql, CommandType.Text);

            return fodderList;
        }

        public DataTable GetFodder(string formulaID)
        {
            DataTable fodderList = null;

            string sql = string.Format(@"SELECT [FormulaID]
                                              ,[FodderID]
	                                          ,Feed_Fodder.Name as FodderName
                                              ,[Quantity]
                                          FROM [Feed_FodderFormula]
                                          JOIN Feed_Fodder
                                          ON Feed_Fodder.ID = Feed_FodderFormula.FodderID
                                          WHERE Feed_FodderFormula.FormulaID = {0}", formulaID);

            fodderList = dataProvider1mutong.FillDataTable(sql, CommandType.Text);

            return fodderList;
        }
    }
}
