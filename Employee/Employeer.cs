﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEmployee
{
    public abstract class Employee : IComparable<Employee>
    {
        protected string _Name;
        protected string _Age;

        protected Employee(string name, string age)
        {
            _Name = name;
            _Age = age;
        }

        public string GetName() => _Name;
        public string GetAge() => _Age;

        public abstract decimal CalulateSallay();

        public int CompareTo(Employee other)
        {
            return this._Name.CompareTo(other._Name);
        }
    }
}