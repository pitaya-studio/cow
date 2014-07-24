using DairyCow.DAL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace DairyCow.BLL
{
    public class FodderBLL
    {
        FodderDAL dalFodder = new FodderDAL();

        public List<Fodder> GetFodder(int pastureID)
        {
            DataTable fodder = this.dalFodder.GetFodder(pastureID);

            List<Fodder> lstFodder = new List<Fodder>();
            foreach (DataRow darFodder in fodder.Rows)
            {
                Fodder fodderItem = WrapFodder(darFodder);
                lstFodder.Add(fodderItem);
            }

            return lstFodder;
        }

        public List<Fodder> GetFodder(string formulaID)
        {
            DataTable fodder = this.dalFodder.GetFodder(formulaID);

            List<Fodder> lstFodder = new List<Fodder>();
            foreach (DataRow darFodder in fodder.Rows)
            {
                Fodder fodderItem = WrapFodderOfFormula(darFodder);
                lstFodder.Add(fodderItem);
            }

            return lstFodder;
        }

        public Fodder WrapFodder(DataRow fodderRow)
        {
            Fodder fodderItem = new Fodder();
            if (fodderRow != null)
            {
                fodderItem.ID = Convert.ToInt32(fodderRow["FodderID"]);
                fodderItem.Name = fodderRow["FodderName"].ToString();
                fodderItem.Description = fodderRow["Description"].ToString();
            }
            return fodderItem;
        }

        public Fodder WrapFodderOfFormula(DataRow fodderRow)
        {
            Fodder fodderItem = new Fodder();
            if (fodderRow != null)
            {
                fodderItem.ID = Convert.ToInt32(fodderRow["FodderID"]);
                fodderItem.Name = fodderRow["FodderName"].ToString();
                fodderItem.Quantity = Convert.ToInt32(fodderRow["Quantity"]);
            }
            return fodderItem;
        }   
     
        public int InsertFodder(Fodder f)
        {
            int temp = 0;
            temp = dalFodder.InsertStandardFodder(f.Name,
                                                    f.Description,
                                                    f.RefPrice,
                                                    f.DM,
                                                    f.NND,
                                                    f.Ca,
                                                    f.P,
                                                    f.CP,
                                                    f.CF,
                                                    f.Fat,
                                                    f.NFE,
                                                    f.ASH,
                                                    f.NDF,
                                                    f.ADF,
                                                    f.NPP,
                                                    f.Arg,
                                                    f.His,
                                                    f.Ile,
                                                    f.Leu,
                                                    f.Lys,
                                                    f.Met,
                                                    f.Cys,
                                                    f.Phe,
                                                    f.Tyr,
                                                    f.Thr,
                                                    f.Trp,
                                                    f.Val,
                                                    f.Na,
                                                    f.Cl,
                                                    f.Mg,
                                                    f.K,
                                                    f.Fe,
                                                    f.Cu,
                                                    f.Mn,
                                                    f.Zn,
                                                    f.Se);
            return temp;
        }
    }
}
