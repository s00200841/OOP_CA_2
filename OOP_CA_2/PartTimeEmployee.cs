using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CA_2
{
    class PartTimeEmployee : Employee
    {
        // Part Time Employee is payed by the hour so consider an average weekly workhours for a part timer
        // then multiply that by 4 for the month then multiply by the hourly rate to recive the monthly Pay
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public PartTimeEmployee(string firstName, string lastName, decimal hourlyRate, double hoursWorked) :base(firstName,lastName)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }
        public override decimal CalculateMonthlyPay()
        {
            decimal HoursWorkedToDecimal = Convert.ToDecimal(HoursWorked);
            decimal monthlypay = Math.Round((HourlyRate * HoursWorkedToDecimal),2);
            return monthlypay;
        }
        public override string ToString()
        {
            return string.Format($"{LastName}, {FirstName} - Part Time").ToString();
        }
    }
}
