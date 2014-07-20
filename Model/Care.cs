using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyCow.Model
{
    public class Care
    {
        public string EarNum { get; set; }
        public int Disease_Id { get; set; }
        public string Prescription { get; set; }
        public int DoctorID { get; set; }
        public DateTime Date { get; set; }
        public int LeftFront { get; set; }
        public int RightFront { get; set; }
        public int RightBack { get; set; }
        public int LeftBack { get; set; }
    }
}
