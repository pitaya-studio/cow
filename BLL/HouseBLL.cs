using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DairyCow.DAL;
using DairyCow.Model;

namespace DairyCow.BLL
{
    public class HouseBLL
    {
        private HouseDAL houseDAL = new HouseDAL();

        public List<House> GetHouseList(int pastureID)
        {
            List<House> list = new List<House>();
            DataTable table = houseDAL.GetHouseTable(pastureID);
            foreach (DataRow item in table.Rows)
            {
                list.Add(WrapHouseItem(item));
            }
            return list;
        }

        public List<House> GetUnusedHouseList(int pastureID)
        {
            return GetHouseList(pastureID).FindAll(p => p.GroupID == 0);
        }

        public House WrapHouseItem(DataRow row)
        {
            House h = new House();
            h.ID = Convert.ToInt32(row["ID"]);
            h.PastureID = Convert.ToInt32(row["PastureID"]);
            h.Name = row["Name"].ToString();
            if (row["GroupID"]!= DBNull.Value)
            {
                h.GroupID = Convert.ToInt32(row["GroupID"]);
            }
            else
            {
                h.GroupID = 0;
            }
            return h;
        }

        public int AddHouse(House house)
        {
            return houseDAL.InsertHouse(house.Name, house.GroupID, house.PastureID);
        }

        public int AddUnusedHouse(House unusedHouse)
        {
            return houseDAL.InsertHouse(unusedHouse.Name, unusedHouse.PastureID);
        }

        public int UpdateHouseGroup(int houseID,int groupID)
        {
            return houseDAL.UpdateHouseGroup(houseID, groupID);
        }

        public int DeleteHouse(House house)
        {
            int temp;
            //如果没有牛，也没有分给牛群，就可以删
            CowBLL cowBLL = new CowBLL();
            List<Cow> myCowList = cowBLL.GetCowList(house.PastureID);
            if(house.GroupID==0 && myCowList.FindAll(p=>p.HouseID==house.ID).Count==0)
            {
                temp=houseDAL.DeleteHouse(house.ID);
            }
            else
            {
                temp = 0;
            }
            return temp;
        }
    }
}
