using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class TimeEmployee : Employee
    {
        const decimal workDays = 20.8m;
        const decimal workHours = 8.0m;
        decimal HourRate { get; set; }

        public TimeEmployee(string Name, string Age, decimal hourRate) : base(Name, Age)
        {
            HourRate = hourRate;
        }

        public override decimal CalulateSallay()
        {
            return workDays *  workHours * HourRate;
        }
    }
}
