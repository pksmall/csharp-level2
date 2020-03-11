using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppEmployee
{
    public class TimeEmployee : Employee
    {
        const decimal workDays = 20.8m;
        const decimal workHours = 8m;
        private decimal _HourRate;

        public TimeEmployee(string Name, 
            string Age, 
            int Department,
            ObservableCollection<Department> ObDep,
            decimal HourRate)  : base(Name, Age, Department, ObDep)
        {
            _HourRate = HourRate;
        }

        public override decimal CalulateSallay()
        {
            return workDays *  workHours * _HourRate;
        }
    }
}
