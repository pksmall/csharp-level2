using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTest
{
    public class FixedEmployee : Employee
    {
        private decimal _Sallary;

        public FixedEmployee(string Name, string Age, decimal Sallary) : base(Name, Age)
        {
            _Sallary = Sallary;
        }

        public override decimal CalulateSallay()
        {
            return _Sallary;
        }

    }
}
