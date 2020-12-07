using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CA_2
{
    class FullTimeEmployee : Employee
    {
        public decimal Salary { get; set; }

        public FullTimeEmployee(string firstName, string lastName, decimal salary) : base(firstName, lastName)
        {
            Salary = salary;
        }

        public decimal CalculateMonthlyPay()
        {
            decimal monthlypay = Salary / 12;
            return monthlypay;
        }

        public override string ToString()
        {
            return string.Format($"{LastName},{FirstName} - Full Time").ToString();
        }

    }
}
