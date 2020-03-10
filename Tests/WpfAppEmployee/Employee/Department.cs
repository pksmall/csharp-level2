using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppEmployee
{ 
    public class Department
    {
        public int DepId { get; set; }
        public string DepartamentName { get; set; }

        public Department(int depId, string departamentName)
        {
            DepId = depId;
            DepartamentName = departamentName;
        }
    }
}
