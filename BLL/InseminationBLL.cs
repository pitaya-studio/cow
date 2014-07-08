using DairyCow.DAL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyCow.BLL
{
    /// <summary>
    /// 配种业务逻辑处理
    /// </summary>
    public class InseminationBLL
    {
        InseminationDAL dalInsemination = new InseminationDAL();

        public List<Insemination> GetInseminationList()
        {
            List<Insemination> lstInsemination = new List<Insemination>();
            DataTable datInsemination = this.dalInsemination.GetInseminationList();
            foreach (DataRow drInsemination in datInsemination.Rows)
            {
                Insemination inseminationItem = WrapInseminationItem(drInsemination);
                lstInsemination.Add(inseminationItem);
            }
            return lstInsemination;
        }

        /// <summary>
        /// 获取最新配种信息
        /// </summary>
        /// <param name="earNum">耳号</param>
        /// <returns></returns>
        public Insemination GetLatestInsemination(int earNum)
        {
            Insemination inseminationInfo = new Insemination();
            DataRow datInsemination = this.dalInsemination.GetLatestInsemination(earNum);
            if (datInsemination!=null)
            {
                inseminationInfo = WrapInseminationItem(datInsemination);
            }
            return inseminationInfo;
        } 

        public Insemination GetInseminationInfo(int earNum)
        {
            Insemination inseminationInfo = new Insemination();
            DataTable datInsemination = this.dalInsemination.GetInseminationList(earNum);
            if (datInsemination != null && datInsemination.Rows.Count == 1)
            {
                inseminationInfo = WrapInseminationItem(datInsemination.Rows[0]);
            }
            return inseminationInfo;
        }

        public Insemination GetInseminationInfo(int earNum, int parityNum, int inseminationNum)
        {
            Insemination inseminationInfo = new Insemination();
            DataTable datInsemination = this.dalInsemination.GetInseminationList(earNum, inseminationNum);
            if (datInsemination != null && datInsemination.Rows.Count == 1)
            {
                inseminationInfo = WrapInseminationItem(datInsemination.Rows[0]);
            }
            return inseminationInfo;
        }

        /// <summary>
        /// 获取所有本繁殖周期配种记录
        /// </summary>
        /// <param name="earNum">耳号</param>
        /// <param name="latestCalvingDate">最近产犊日期，如为青年牛，则取日期最小值</param>
        /// <returns>配种记录list</returns>
        public List<Insemination> GetInseminationList(int earNum, DateTime latestCalvingDate)
        {
            List<Insemination> list = new List<Insemination>();
            DataTable table = this.dalInsemination.GetInseminationTable(earNum, latestCalvingDate);
            foreach (DataRow item in table.Rows)
            {
                list.Add(WrapInseminationItem(item));
            }
            return list;
        }


        /// <summary>
        /// 保存一头牛的配种信息
        /// </summary>
        /// <param name="insem"></param>
        public int UpdateInseminationInfo(Insemination insem)
        {
            return dalInsemination.UpdateInseminationInfo(insem);
        }

        public bool IsInsemExist(int earNum, int inseminationNum)
        {
            return dalInsemination.IsInsemExist(earNum, inseminationNum);
        }

        private Insemination WrapInseminationItem(DataRow inseminationRow)
        {
            Insemination inseminationItem = new Insemination();
            if (inseminationRow != null)
            {
                if (Convert.ToInt32(inseminationRow["ID"]) != 0)
                {
                    inseminationItem.ID = Convert.ToInt32(inseminationRow["ID"]);
                }
                inseminationItem.EarNum = Convert.ToInt32(inseminationRow["EarNum"]);
                if (inseminationRow["InseminationNum"] != null && !string.IsNullOrWhiteSpace(inseminationRow["InseminationNum"].ToString()))
                {
                    inseminationItem.InseminationNum = Convert.ToInt32(inseminationRow["InseminationNum"]);
                }
                inseminationItem.SemenNum = inseminationRow["SemenNum"].ToString();
                if (inseminationRow["SemenType"] != null && !string.IsNullOrWhiteSpace(inseminationRow["SemenType"].ToString()))
                {
                    inseminationItem.SemenType = Convert.ToInt32(inseminationRow["SemenType"]);
                }
                if (inseminationRow["EstrusFindType"] != null && !string.IsNullOrWhiteSpace(inseminationRow["EstrusFindType"].ToString()))
                {
                    inseminationItem.EstrusFindType = Convert.ToInt32(inseminationRow["EstrusFindType"]);
                }
                inseminationItem.OperateDate = Convert.ToDateTime(inseminationRow["OperateDate"]);
                inseminationItem.Operator = inseminationRow["Operator"].ToString();
                inseminationItem.Description = inseminationRow["Description"].ToString();

                inseminationItem.EstrusDate = Convert.ToDateTime(inseminationRow["EstrusDate"]);
                if (inseminationRow["EstrusType"] != null && string.IsNullOrWhiteSpace(inseminationRow["EstrusType"].ToString()))
                {
                    inseminationItem.EstrusType = Convert.ToInt32(inseminationRow["EstrusType"]);
                }
                inseminationItem.EstrusFindPerson = inseminationRow["EstrusFindPerson"].ToString();
            }
            return inseminationItem;
        }

        public int InsertInseminationInfo(Insemination insemination)
        {
            return dalInsemination.InsertInseminationInfo(insemination);
        }

        /// <summary>
        /// 禁配
        /// </summary>
        /// <param name="earNum"></param>
        /// <returns></returns>
        public int ForbidInsemination(int earNum)
        {
            return dalInsemination.ForbidInsemination(earNum);
        }

        //根据牛的耳号获得最近一次牛的配种ID
        public int GetLatestInseminationID(int earNum)
        {
            return dalInsemination.GetLatestInseminationID(earNum);
        }

        //解禁
        public object UnDoForbidInsemination(int earNum)
        {
            return dalInsemination.UnDoForbidInsemination(earNum);
        }
    }
}
