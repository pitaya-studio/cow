using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyCow.Model
{
    /// <summary>
    /// 牛群分配，将牛群分配给指定的配种员
    /// </summary>
    public class CowGroup
    {
        //牛群分配ID
        public int ID { get; set; }
        //牛群名称
        public string Name { get; set; }
        //牧场ID
        public int PastureID { get; set; }
        //牧场名称
        public string PastureName { get; set; }
        // 状态ID
        public int Type { get; set; }
        //配方ID
        public int FormulaID { get; set; }
        //配方名称
        public string FormulaName { get; set; }
        //配种员ID
        public int InsemOperatorID { get; set; }
        //配种员姓名
        public string InsemOperatorName { get; set; }
        //牛群描述
        public string Description { get; set; }
    }
}
