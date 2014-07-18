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
    public class StrayBAL
    {
        private StrayDAL strayDAL = new StrayDAL();
        public List<Stray> GetStrayList(int pastureID)
        {
            DataTable table = strayDAL.GetStrayTable(pastureID);
            List<Stray> list = new List<Stray>();
            foreach (DataRow item in table.Rows)
            {
                list.Add(WrapStrayItem(item));
            }
            return list;
        }

        public Stray WrapStrayItem(DataRow row)
        {
            Stray stray = new Stray();
            stray.EarNum = Convert.ToInt32(row["EarNum"]);
            stray.PastureID = Convert.ToInt32(row["PastureID"]);
            stray.StrayType = Convert.ToInt32(row["StrayType"]);
            stray.IsSold = Convert.ToInt32(row["IsSold"]);
            stray.Price = Convert.ToSingle(row["Price"]);
            stray.Reason = row["Reason"].ToString();
            return stray;
        }

        public int InsertStray(Stray s)
        {
            return strayDAL.InsertStray(s.EarNum, s.PastureID, s.StrayType, s.IsSold, s.Price, s.Reason);
        }

    }
}
