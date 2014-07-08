using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyCow.Model
{
     /// <summary>
     /// 牛产犊记录
     /// </summary>
    public class Calving
    {
        public DateTime Birthday{get;set;}
        public int EarNum { get; set; }
        //public int ChildEarNum { get; set; }
        public string FatherSememNum { get; set; }
        public int OperatorID { get; set; }
        public string OperatorName { get; set; }
        public BirthType BirthType { get; set; }
        public string Difficulty { get; set; }
        public string PositionOfFetus { get; set; }
        public string Comment { get; set; }
        public bool InParityCount { get; set; }
        public int NumberOfMale { get; set; }
        public int NumberOfFemale { get; set; }
    }

    public enum BirthType
    {
        Normal=0,
        PrematureBirth=1,
        Miscarry=2
    }
}
