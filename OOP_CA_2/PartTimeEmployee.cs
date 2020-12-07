using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CA_2
{
    class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public PartTimeEmployee(string firstName, string lastName, decimal hourlyRate, double hoursWorked) :base(firstName,lastName)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }
        public decimal CalculateMonthlyPay()
        {
            decimal HoursWorkedToDecimal = Convert.ToDecimal(HoursWorked);
            decimal monthlypay = (HourlyRate * HoursWorkedToDecimal);
            return monthlypay;
        }
        public override string ToString()
        {
            return string.Format($"{LastName},{FirstName} - Part Time").ToString();
        }
    }
}
