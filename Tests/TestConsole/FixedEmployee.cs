using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class FixedEmployee : Employee
    {

        decimal Sallary { get; set; }

        public FixedEmployee(string Name, string Age, decimal sallary) : base(Name, Age)
        {
            Sallary = sallary;
        }

        public override decimal CalulateSallay()
        {
            return Sallary;
        }

    }
}
