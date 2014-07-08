using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyCow.Model
{
    /// <summary>
    /// 饲料
    /// </summary>
    public class Fodder
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public double DryMatter { get; set; }
        public double NND { get; set; }
        public double Calcium { get; set; }
        public double Phosphorus { get; set; }
        public double Protein { get; set; }
        public double RefPrice { get; set; }
    }
}
