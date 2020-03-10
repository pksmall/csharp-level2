using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppEmployee
{
    public class FixedEmployee : Employee
    {
        private decimal _Sallary;

        public FixedEmployee(string Name, string Age, 
            int Department, 
            ObservableCollection<Department> ObDep, 
            decimal Sallary) : base(Name, Age, Department, ObDep)
        {
            _Sallary = Sallary;
        }

        public override decimal CalulateSallay()
        {
            return _Sallary;
        }

    }
}
