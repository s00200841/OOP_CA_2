using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CA_2
{
    class FullTimeEmployee : Employee
    {
        // FullTime Employee is taking a salary.
        // So take a realistic salary over a year and here we will divide by 12 to get a monthly salary.
        // Example a Programmer with more than 5 years experience can earn up to €70,000 per year.
        public decimal Salary { get; set; }

        public FullTimeEmployee(string firstName, string lastName, decimal salary) : base(firstName, lastName)
        {
            Salary = salary;
        }

        // Calculates Monthly pay by dividing Yearly salary by 12
        // Since it is currency after all. Round down to 2 decimal places
        public override decimal CalculateMonthlyPay()
        {
            decimal monthlypay = Math.Round((Salary / 12),2);
            return monthlypay;
        }

        public override string ToString()
        {
            return string.Format($"{LastName.ToUpper()}, {FirstName} - Full Time").ToString();
        }

    }
}
