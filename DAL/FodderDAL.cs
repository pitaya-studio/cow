using DairyCow.DAL.Base;
using System.Data;

namespace DairyCow.DAL
{
    public class FodderDAL : BaseDAL
    {
        /// <summary>
        /// 获取牧场饲料表
        /// </summary>
        /// <param name="pastureID"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 获取配方标准饲料
        /// </summary>
        /// <param name="formulaID"></param>
        /// <returns></returns>
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

        public int InsertStandardFodder(string name,string desc,double refPrice,double nuDM,
                                                                                            double nuNND,
                                                                                            double nuCa,
                                                                                            double nuP,
                                                                                            double nuCP,
                                                                                            double nuCF,
                                                                                            double nuFat,
                                                                                            double nuNFE,
                                                                                            double nuASH,
                                                                                            double nuNDF,
                                                                                            double nuADF,
                                                                                            double nuNPP,
                                                                                            double nuArg,
                                                                                            double nuHis,
                                                                                            double nuIle,
                                                                                            double nuLeu,
                                                                                            double nuLys,
                                                                                            double nuMet,
                                                                                            double nuCys,
                                                                                            double nuPhe,
                                                                                            double nuTyr,
                                                                                            double nuThr,
                                                                                            double nuTrp,
                                                                                            double nuVal,
                                                                                            double nuNa,
                                                                                            double nuCl,
                                                                                            double nuMg,
                                                                                            double nuK,
                                                                                            double nuFe,
                                                                                            double nuCu,
                                                                                            double nuMn,
                                                                                            double nuZn,
                                                                                            double nuSe
                                                                                            )
        {
            string sql = string.Format(@"Insert [Feed_Fodder] ([Name],
                                                                [Description],
                                                                [RefPrice],
                                                                [DM],
                                                                [NND],
                                                                [Ca],
                                                                [P],
                                                                [CP],
                                                                [CF],
                                                                [Fat],
                                                                [NFE],
                                                                [ASH],
                                                                [NDF],
                                                                [ADF],
                                                                [NPP],
                                                                [Arg],
                                                                [His],
                                                                [Ile],
                                                                [Leu],
                                                                [Lys],
                                                                [Met],
                                                                [Cys],
                                                                [Phe],
                                                                [Tyr],
                                                                [Thr],
                                                                [Trp],
                                                                [Val],
                                                                [Na],
                                                                [Cl],
                                                                [Mg],
                                                                [K],
                                                                [Fe],
                                                                [Cu],
                                                                [Mn],
                                                                [Zn],
                                                                [Se]
                                                                ) values ('{0}',
                                                                            '{1}',
                                                                            {2},
                                                                            {3},
                                                                            {4},
                                                                            {5},
                                                                            {6},
                                                                            {7},
                                                                            {8},
                                                                            {9},
                                                                            {10},
                                                                            {11},
                                                                            {12},
                                                                            {13},
                                                                            {14},
                                                                            {15},
                                                                            {16},
                                                                            {17},
                                                                            {18},
                                                                            {19},
                                                                            {20},
                                                                            {21},
                                                                            {22},
                                                                            {23},
                                                                            {24},
                                                                            {25},
                                                                            {26},
                                                                            {27},
                                                                            {28},
                                                                            {29},
                                                                            {30},
                                                                            {31},
                                                                            {32},
                                                                            {33},
                                                                            {34},
                                                                            {35}
                                                                            )",name,
                                                                            desc,
                                                                            refPrice,
                                                                             nuDM,
                                                                             nuNND,
                                                                             nuCa,
                                                                             nuP,
                                                                             nuCP,
                                                                             nuCF,
                                                                             nuFat,
                                                                             nuNFE,
                                                                             nuASH,
                                                                             nuNDF,
                                                                             nuADF,
                                                                             nuNPP,
                                                                             nuArg,
                                                                             nuHis,
                                                                             nuIle,
                                                                             nuLeu,
                                                                             nuLys,
                                                                             nuMet,
                                                                             nuCys,
                                                                             nuPhe,
                                                                             nuTyr,
                                                                             nuThr,
                                                                             nuTrp,
                                                                             nuVal,
                                                                             nuNa,
                                                                             nuCl,
                                                                             nuMg,
                                                                             nuK,
                                                                             nuFe,
                                                                             nuCu,
                                                                             nuMn,
                                                                             nuZn,
                                                                             nuSe
                                                                            );
            return dataProvider1mutong.ExecuteNonQuery(sql, CommandType.Text);

        }
    }
}
