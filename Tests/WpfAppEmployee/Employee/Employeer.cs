using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppEmployee
{
    public abstract class Employee : IComparable<Employee>
    {
        protected string _Name;
        protected string _Age;
        protected int _Department;
        public ObservableCollection<Department> EmployeeDepartment { get; set; }

        protected Employee(string name, string age, int department, ObservableCollection<Department> obdep)
        {
            _Name = name;
            _Age = age;
            _Department = department;
            EmployeeDepartment = obdep;

            //EmployeeDepartment = new ObservableCollection<Department>
            //{
            //    new Department(1, "aaa"),
            //    new Department(2, "bbb"),
            //    new Department(3, "ccc"),
            //    new Department(4, "ddd"),
            //};
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public string Age
        {
            get
            {
                return _Age;
            }
            set
            {
                _Age = value;
            }
        }

        public decimal Sallary
        {
            get
            {
                return CalulateSallay();
            }
        }

        public int Department
        {
            get
            {
                return _Department;
            }
            set 
            {
                _Department = value;
            }
        }

        public abstract decimal CalulateSallay();

        public int CompareTo(Employee other)
        {
            return this._Name.CompareTo(other._Name);
        }
    }
}
