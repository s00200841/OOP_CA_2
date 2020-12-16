using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CA_2
{
    class PartTimeEmployee : Employee
    {
        // Part Time Employee is payed by the hour so consider an average weekly work hours for a part timer
        // then example( multiply that by 4 for the month). This would result in an amount of hours a month one would work
        // then multiply by the hourly rate to recive the monthly Pay
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public PartTimeEmployee(string firstName, string lastName, decimal hourlyRate, double hoursWorked) :base(firstName,lastName)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }
        // Calculates Montly Pay by multiplying the hours worked by the hourly pay rate
        // Since it is currency after all. Round down to 2 deciml places
        public override decimal CalculateMonthlyPay()
        {
            decimal HoursWorkedToDecimal = Convert.ToDecimal(HoursWorked);
            decimal monthlypay = Math.Round((HourlyRate * HoursWorkedToDecimal),2);
            return monthlypay;
        }
        public override string ToString()
        {
            return string.Format($"{LastName.ToUpper()}, {FirstName} - Part Time").ToString();
        }
    }
}
