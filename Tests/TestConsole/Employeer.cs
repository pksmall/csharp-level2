using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public abstract class Employee : IComparable<Employee>
    {
        public string Name { get; set; }
        public string Age { get; set; }

        protected Employee(string name, string age)
        {
            Name = name;
            Age = age;
        }

        public abstract decimal CalulateSallay();

        public int CompareTo(Employee other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
