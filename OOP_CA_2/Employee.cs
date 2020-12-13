using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CA_2
{
    abstract class Employee
    {
        // Employee is the parent class and holds Simple stuff like First and Last Name
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public virtual decimal CalculateMonthlyPay()
        {
            decimal monthlypay = 0;
            return monthlypay;
        }

        public override string ToString()
        {
            return string.Format($"{LastName} , {FirstName}").ToString();
        }
    }
}
