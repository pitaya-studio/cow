using DairyCow.DAL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DairyCow.BLL
{
    public class FormulaBLL
    {
        private FormulaDAL dalFormula = new FormulaDAL();
        CowGroupDAL group = new CowGroupDAL();

        public Dictionary<string, double> ExecFodder(int groupID, int machineNumber)
        {
            Dictionary<string, double> ret = new Dictionary<string, double>();
            int cowCount = group.GetCowCount(groupID);
            DataTable dt = dalFormula.GetFormulaFodder(groupID);
            foreach (DataRow dr in dt.Rows)
            {
                ret.Add(dr["FodderName"].ToString(), Convert.ToDouble(dr["Quantity"]) * cowCount / machineNumber);
            }
            return ret;
        }

        //返回值说明： 牛舍为key，value 的 list中按顺序为早中晚的喂的量。
        public Dictionary<string, List<double>> ExecFeed(int groupID, int feedTimes, bool isSummer)
        {
            DataTable dtCowCountInHouse = group.GetCowCountInHouse(groupID);
            DataTable dtFormularFodder = dalFormula.GetFormulaFodder(groupID);
            
            double quantity = 0;
            foreach(DataRow row in dtFormularFodder.Rows)
            {
                quantity += Convert.ToDouble(row["Quantity"]);
            }

            Dictionary<string, List<double>> houseFeed = new Dictionary<string, List<double>>();
            foreach(DataRow row in dtCowCountInHouse.Rows)
            {
                string houseName = row["Name"].ToString();
                int count = Convert.ToInt32(row["CowCount"]);
                List<double> dailyFeed = new List<double>();
                if(isSummer)
                {
                    dailyFeed.Add(quantity * count * 0.35);
                    dailyFeed.Add(quantity * count * 0.3);
                    dailyFeed.Add(quantity * count * 0.35);
                }
                else
                {
                    double oneTime = quantity * count / feedTimes;
                    for (int i = 0; i < feedTimes; i++)
                    {
                        dailyFeed.Add(oneTime);
                    }
                }
                if(!houseFeed.ContainsKey(houseName))
                {
                    houseFeed.Add(houseName, dailyFeed);
                }                
            }

            return houseFeed;
        }

        public List<Formula> GetFormulaList()
        {
            DataTable datFormula = this.dalFormula.GetFormulaList();
            List<Formula> lstFormula = new List<Formula>();

            foreach (DataRow formula in datFormula.Rows)
            {
                Formula formulaItem = WrapFormula(formula);
                lstFormula.Add(formulaItem);
            }

            return lstFormula;
        }

        public Formula GetFormulaInfoList(string formulaID)
        {
            Formula formula = new Formula();

            DataTable datFormula = this.dalFormula.GetFormulaInfoList(formulaID);
            if (datFormula != null && datFormula.Rows.Count > 0)
            {
                List<Fodder> lstFormula = new List<Fodder>();
                foreach (DataRow darFormula in datFormula.Rows)
                {
                    Fodder formulaItem = new Fodder()
                    {
                        ID = Convert.ToInt32(darFormula["FodderID"]),
                        Name = darFormula["FodderName"].ToString(),
                        Quantity = Convert.ToDouble(darFormula["Quantity"]),
                        DryMatter = Convert.ToDouble(darFormula["DryMatter"]),
                        NND = Convert.ToDouble(darFormula["NND"]),
                        Calcium = Convert.ToDouble(darFormula["Calcium"]),
                        Phosphorus = Convert.ToDouble(darFormula["Phosphorus"]),
                        Protein = Convert.ToDouble(darFormula["Protein"]),
                        RefPrice = Convert.ToDouble(darFormula["RefPrice"])
                    };
                    lstFormula.Add(formulaItem);
                }

                formula.ID = Convert.ToInt32(datFormula.Rows[0]["FormulaID"]);
                formula.Name = datFormula.Rows[0]["FormulaName"].ToString();
                formula.Fodder = lstFormula;
            }

            return formula;
        }

        public Formula WrapFormula(DataRow formulaRow)
        {
            Formula formulaItem = new Formula();
            if (formulaRow != null)
            {
                formulaItem.ID = Convert.ToInt32(formulaRow["ID"]);
                formulaItem.Name = formulaRow["Name"].ToString();
            }
            return formulaItem;
        }

        public int SaveFormula(string formulaID, string formulaName, List<Fodder> fodder)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(formulaID))
            {
                result = this.dalFormula.UpdateFormula(formulaID, formulaName, fodder);
            }
            else
            {
                result = this.dalFormula.InsertFormula(formulaName, fodder);
            }
            return result;
        }

        public void UpdateFormulaOfCowGroup(string formulaID, string cowGroupID)
        {
            this.dalFormula.UpdateFormulaOfCowGroup(formulaID, cowGroupID);
        }
    }
}
