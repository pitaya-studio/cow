using DairyCow.DAL.Base;
using System.Data;

namespace DairyCow.DAL
{
    public class PastureDAL:BaseDAL
    {
        public DataTable GetPasture()
        {
            string sql = string.Format(@"SELECT ID,Name FROM [DBO].[BASE_PASTURE]");
            DataTable cowGroup = dataProvider1mutong.FillDataTable(sql, CommandType.Text);
            return cowGroup;
        }
    }
}
