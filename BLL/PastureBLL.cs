using DairyCow.DAL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace DairyCow.BLL
{
    public class PastureBLL
    {
        private PastureDAL dalPasture = new PastureDAL();

        public List<Pasture> GetPasture()
        {
            List<Pasture> lstPasture = new List<Pasture>();

            DataTable datPasture = this.dalPasture.GetPasture();
            if (datPasture != null && datPasture.Rows.Count > 0)
            {
                foreach (DataRow drPasture in datPasture.Rows)
                {
                    lstPasture.Add(new Pasture()
                    {
                        ID = Convert.ToInt32(drPasture["ID"].ToString()),
                        Name = drPasture["Name"].ToString()
                    });
                }
            }

            return lstPasture;
        }
    }
}
