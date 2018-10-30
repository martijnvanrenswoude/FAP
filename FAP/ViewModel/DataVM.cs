using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.ViewModel
{
    public class DataVM
    {
        public string Name { get; set; }
        public string DayOfEmployment { get; set; }

        public DataVM(string Name, string DayOfEmployment)
        {
            this.Name = Name;
            this.DayOfEmployment = DayOfEmployment;
        }
    }
}
