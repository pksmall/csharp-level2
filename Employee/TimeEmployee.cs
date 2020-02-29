using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEmployee
{
    public class TimeEmployee : Employee
    {
        const decimal workDays = 20.8m;
        const decimal workHours = 8m;
        private decimal _HourRate;

        public TimeEmployee(string Name, string Age, decimal HourRate)  : base(Name, Age)
        {
            _HourRate = HourRate;
        }

        public override decimal CalulateSallay()
        {
            return workDays *  workHours * _HourRate;
        }
    }
}
