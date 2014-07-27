using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyCow.Model
{
    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int SupervisorID { get; set; }
        public bool CanBreed { get; set; }
        public bool CanFeed { get; set; }
        public bool CanMedical { get; set; }
        public bool CanMilk { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDirector { get; set; }

        public List<string> Menus { get; set; }
    }
}
