using DairyCow.DAL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace DairyCow.BLL
{
    public class CowGroupBLL
    {
        CowGroupDAL dalCowGroup = new CowGroupDAL();

        public List<CowGroup> GetCowGroupList()
        {
            List<CowGroup> lstCowGroup = new List<CowGroup>();
            DataTable datCowGroup = this.dalCowGroup.GetCowGroupTable();
            foreach (DataRow drCowGroup in datCowGroup.Rows)
            {
                CowGroup cowGroupItem = WrapCowGroupItem(drCowGroup);
                lstCowGroup.Add(cowGroupItem);
            }
            return lstCowGroup;
        }

        public int UpdateCowGroupInsemOperator(int cowGroupID, int insemOperatorID)
        {
            return dalCowGroup.UpdateCowGroupInsemOperator(cowGroupID, insemOperatorID);
        }

        public int UpdateCowGroupFeeder(int cowGroupID,int feederID)
        {
            return dalCowGroup.UpdateCowGroupFeeder(cowGroupID, feederID);
        }

        public int UpdateCowGroupDoctor(int cowGroupID,int doctorID)
        {
            return dalCowGroup.UpdateCowGroupDoctor(cowGroupID,doctorID);
        }

        private CowGroup WrapCowGroupItem(DataRow cowGroupRow)
        {
            CowGroup cowGroupItem = new CowGroup();
            if (cowGroupRow != null)
            {
                if (Convert.ToInt32(cowGroupRow["ID"]) != 0)
                {
                    cowGroupItem.ID = Convert.ToInt32(cowGroupRow["ID"]);
                }
                cowGroupItem.Name = cowGroupRow["GroupName"].ToString();
                if (cowGroupRow["PastureID"] != null && !string.IsNullOrWhiteSpace(cowGroupRow["PastureID"].ToString()))
                {
                    cowGroupItem.PastureID = Convert.ToInt32(cowGroupRow["PastureID"]);
                }
                if (cowGroupRow["FormulaID"] != null && !string.IsNullOrWhiteSpace(cowGroupRow["FormulaID"].ToString()))
                {
                    cowGroupItem.FormulaID = Convert.ToInt32(cowGroupRow["FodderFormulaID"]);
                }
                if (cowGroupRow["InsemOperatorID"] != null && !string.IsNullOrWhiteSpace(cowGroupRow["InsemOperatorID"].ToString()))
                {
                    cowGroupItem.InsemOperatorID = Convert.ToInt32(cowGroupRow["InsemOperatorID"]);
                }

                if (cowGroupRow["FeedOperatorID"] != DBNull.Value)
                {
                    cowGroupItem.FeederID = Convert.ToInt32(cowGroupRow["FeedOperatorID"]);
                }
                UserBLL u = new UserBLL();
                cowGroupItem.FeederName = u.GetUsers().Find(p => p.ID == cowGroupItem.FeederID).Name;
                if (cowGroupRow["DoctorID"] != DBNull.Value)
                {
                    cowGroupItem.DoctorID = Convert.ToInt32(cowGroupRow["DoctorID"]);
                }
                cowGroupItem.DoctorName = u.GetUsers().Find(p => p.ID == cowGroupItem.DoctorID).Name;
            }
            return cowGroupItem;
        }

        public List<CowGroup> GetCowGroupInfo()
        {
            List<CowGroup> lstCowGroup = new List<CowGroup>();

            DataTable datCowGroup = this.dalCowGroup.GetCowGroupInfo();
            foreach (DataRow row in datCowGroup.Rows)
            {
                CowGroup info = new CowGroup();
                info.ID = Convert.ToInt32(row["ID"]);
                info.Name = row["Name"].ToString();
                info.TypeNum = Convert.ToInt32(row["Type"]);
                info.FormulaName = row["FormulaName"].ToString();
                info.PastureName = row["PastureName"].ToString();
                info.Description = row["Description"].ToString();
                lstCowGroup.Add(info);
            }

            return lstCowGroup;
        }

        public int GetFormulaIDByGroupID(int id)
        {
            return dalCowGroup.GetFormulaIDByGroupID(id);
        }

        public CowGroup GetCowGroupInfo(int id)
        {
            CowGroup cowGroupItem = new CowGroup();
            DataTable datCowGroup = this.dalCowGroup.GetCowGroupTableByID(id);
            if (datCowGroup != null && datCowGroup.Rows.Count == 1)
            {
                DataRow cowGroupRow = datCowGroup.Rows[0];
                cowGroupItem.ID = Convert.ToInt32(cowGroupRow["ID"]);
                cowGroupItem.Name = cowGroupRow["Name"].ToString();
                cowGroupItem.TypeNum = Convert.ToInt32(cowGroupRow["Type"]);
                cowGroupItem.PastureID = Convert.ToInt32(cowGroupRow["PastureID"]);
                cowGroupItem.FormulaID = Convert.ToInt32(cowGroupRow["FormulaID"]);
                cowGroupItem.DoctorID = Convert.ToInt32(cowGroupRow["DoctorID"]);
                cowGroupItem.Description = cowGroupRow["Description"].ToString();
            }
            return cowGroupItem;
        }

        public int UpdateCowGroupInfo(CowGroup group)
        {
            return this.dalCowGroup.UpdateCowGroupInfo(group);
        }

        /// <summary>
        /// 增加一个群，输入基本信息。（不包含配方，配种员，饲养员和兽医）
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public int AddCowGroupWithBasicInfo(CowGroup group)
        {
            if (String.IsNullOrEmpty(group.Description))
	        {
		        group.Description=String.Empty;
	        }
            return dalCowGroup.InsertCowGroup(group.Name, group.PastureID, group.TypeNum, group.Description);
        }
        ///<summary>
        /// 增加一个群，输入完全信息,包含配方，配种员，饲养员和兽医。
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public int AddCowGroupWithFullInfo(CowGroup group)
        {
            if (String.IsNullOrEmpty(group.Description))
            {
                group.Description = String.Empty;
            }
            return dalCowGroup.InsertCowGroup(group.Name, group.PastureID, group.TypeNum, group.Description,group.FormulaID,group.InsemOperatorID,group.FeederID,group.DoctorID);
        }
        /// <summary>
        /// 删除某个群，必须牛群中不含任何牛。
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns>返回删除行数，未删除返回0.</returns>
        public int DeleteCowGroup(int groupID)
        {
            return dalCowGroup.DeleteCowGroupByID(groupID);
        }
    }
}
