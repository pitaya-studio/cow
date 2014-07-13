using DairyCow.DAL;
using DairyCow.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;

namespace DairyCow.BLL
{
    public class CowBLL
    {
        CowDAL dalCow = new CowDAL();

        /// <summary>
        /// 获取当前用户的牧场Cowlist
        /// </summary>
        /// <returns></returns>
        public List<Cow> GetCowList()
        {
            List<Cow> lstCow = new List<Cow>();

            DataTable datCow = this.dalCow.GetCowList(UserBLL.Instance.CurrentUser.Pasture.ID);
            foreach (DataRow drCow in datCow.Rows)
            {
                Cow cowItem = WrapCowItem(drCow);
                lstCow.Add(cowItem);
            }

            return lstCow;
        }

        /// <summary>
        /// 获取牧场Cowlist
        /// </summary>
        /// <param name="pastureID">牧场ID</param>
        /// <returns></returns>
        public List<Cow> GetCowList(int pastureID)
        {
            List<Cow> lstCow = new List<Cow>();

            DataTable datCow = this.dalCow.GetCowList(pastureID);
            foreach (DataRow drCow in datCow.Rows)
            {
                Cow cowItem = WrapCowItem(drCow);
                lstCow.Add(cowItem);
            }

            return lstCow;
        }

        public Cow GetCowInfo(int earNum)
        {
            Cow cow = new Cow();
            DataTable datCow = this.dalCow.GetCowInfo(earNum);
            if (datCow != null && datCow.Rows.Count == 1)
            {
                cow = WrapCowItem(datCow.Rows[0]);
            }
            return cow;
        }

        private Cow WrapCowItem(DataRow cowRow)
        {
            Cow cowItem = new Cow();
            if (cowRow != null)
            {
                cowItem.EarNum = Convert.ToInt32(cowRow["EarNum"]);
                cowItem.DisplayEarNum = cowRow["DisplayEarNum"].ToString();
                cowItem.GroupID = Convert.ToInt32(cowRow["GroupID"]);
                cowItem.GroupName = cowRow["GroupName"].ToString();
                cowItem.Gender = cowRow["Gender"].ToString();
                cowItem.FarmCode = cowRow["FarmID"].ToString();
                cowItem.BirthDate = Convert.ToDateTime(cowRow["BirthDate"]);
                DateTime dtNow = DateTime.Now;
                //cowItem.AgeMonth = (dtNow.Year - cowItem.BirthDate.Year) * 12 + (dtNow.Month - cowItem.BirthDate.Month);
                
                if (cowRow["BirthWeight"] != null && !string.IsNullOrWhiteSpace(cowRow["BirthWeight"].ToString()))
                {
                    cowItem.BirthWeight = float.Parse(cowRow["BirthWeight"].ToString());
                }
                cowItem.Color = cowRow["Color"].ToString();


                //经产牛和青年牛才有繁殖状态，从繁殖相关事件表可以得出，初始买的牛必须输入
                if (cowRow["Status"] != DBNull.Value)
                {
                    cowItem.Status = GetCowStatus(Convert.ToInt32(cowRow["Status"]));
                }
                else
                {
                    cowItem.Status = String.Empty;
                }
                int ill = Convert.ToInt32(cowRow["IsIll"]);
                if (ill==0)
                {
                    cowItem.IsIll = false;
                }
                else
                {
                    cowItem.IsIll = true;
                }

            }
            return cowItem;
        }

        private string GetCowStatus(int i)
        {
            switch (i)
            {
                case 0:
                    return "未配";
                case 1:
                    return "已配未检";
                case 2:
                    return "初检-";
                case 3:
                    return "初检+";
                case 4:
                    return "复检-";
                case 5:
                    return "复检+";
                case 6:
                    return "禁配";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 获取牛群里所有牛
        /// </summary>
        /// <param name="farmID">牧场ID</param>
        /// <param name="groupID">牛群ID</param>
        /// <returns>牛列表</returns>
        public List<Cow> GetCowsByGroup(int groupID)
        {
            List<Cow> lstCow = new List<Cow>();

            DataTable datCow = this.dalCow.GetCowListByFarmGroup(UserBLL.Instance.CurrentUser.Pasture.ID, groupID);
            foreach (DataRow drCow in datCow.Rows)
            {
                Cow cowItem = WrapCowItem(drCow);
                lstCow.Add(cowItem);
            }

            return lstCow;
        }

        /// <summary>
        /// 获取某繁殖状态的牛
        /// </summary>
        /// <param name="farmID">牧场ID</param>
        /// <param name="status">状态号</param>
        /// <returns>牛列表</returns>
        public List<Cow> GetCowsByFarmStatus(int status)
        {
            List<Cow> lstCow = new List<Cow>();

            DataTable datCow = this.dalCow.GetCowListByFarmStatus(UserBLL.Instance.CurrentUser.Pasture.ID, status);
            foreach (DataRow drCow in datCow.Rows)
            {
                Cow cowItem = WrapCowItem(drCow);
                lstCow.Add(cowItem);
            }

            return lstCow;
        }



    }
}
