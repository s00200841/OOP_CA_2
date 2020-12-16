using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP_CA_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// S00200841
    /// Andrew Casey
    /// started monday 07/12/2020 start: 10:00 end: 1:00 *** start: 2:00 end: 3:30 *** start: 5:15 end: 8:30
    /// Added as far as two check boxes and had to ask how to sort for individual clicks need to optimise next before moving on
    /// On Part 13 Going fairly good sofar
    /// {Clear() pt 14 is added}, pt 13 need to Add Update and Delete 
    /// Add() works 
    /// TODO: cboxes are both off at start but list shows -  will not show if 
    /// Have a Lot of work piling up and have the free time today so i real went through quite a bit
    /// Im Preaty much done on day one but i will leave the sending till i give it a day or two and review my code of any further updating / fixing
    /// Sure Ill find something i could add or that i have missed
    /// started sunday 13.12.2020 start: 4:00 end: 5:40
    /// looked over code. Forgot to add order and capital letters for last name, should work fine now
    /// started Wednesday 16/12/2020 start 11:20
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        ObservableCollection<Employee> filterEmployees = new ObservableCollection<Employee>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // PartTimers take Name First-Last then hourlyRate and finally hours worked
            PartTimeEmployee pTE1 = new PartTimeEmployee("Johnny", "KALLISTER", 11, 96);
            PartTimeEmployee pTE2 = new PartTimeEmployee("Abraham", "JOHNSTON", 12, 112);

            // Fulltimers take Name First-Last and a Years Salary
            FullTimeEmployee fTE1 = new FullTimeEmployee("Mike", "MANN", 32000);
            FullTimeEmployee fTE2 = new FullTimeEmployee("Mikey", "DEAN", 24000);

            employees.Add(pTE1);
            employees.Add(pTE2);
            employees.Add(fTE1);
            employees.Add(fTE2);

            lbxEmployeeLists.ItemsSource = employees.OrderBy(c => c.LastName);
        }

        // all premade Employees will be shown on the screen as program starts
        private void lbxEmployeeLists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee selectedEmployee = lbxEmployeeLists.SelectedItem as Employee;

            if (selectedEmployee != null)
            {
                // In here this will be used to fill the text boxes on the right with whichever employee we have selected
                tbxFName.Text = selectedEmployee.FirstName;
                tbxLName.Text = selectedEmployee.LastName;
                foreach(Employee employee in employees)
                {
                    if (selectedEmployee == employee as FullTimeEmployee)
                    {
                        FullTimeEmployee selectFullTimeEmployee = lbxEmployeeLists.SelectedItem as FullTimeEmployee;
                        tbxSalary.Text = selectFullTimeEmployee.Salary.ToString();
                        tbxHrsWorked.Clear();
                        tbxHourlyRate.Clear();
                        rbtnFT.IsChecked = true;
                    }
                    if (selectedEmployee == employee as PartTimeEmployee)
                    {
                        PartTimeEmployee selectPartTimeEmployee = lbxEmployeeLists.SelectedItem as PartTimeEmployee;
                        tbxSalary.Clear();
                        tbxHrsWorked.Text = selectPartTimeEmployee.HoursWorked.ToString();
                        tbxHourlyRate.Text = selectPartTimeEmployee.HourlyRate.ToString();
                        rbtnPT.IsChecked = true;
                    }
                }
                tblkMonthlyPay.Text = selectedEmployee.CalculateMonthlyPay().ToString();
            }
        }

        // Have check boxes and uncheck boxes
        private void cboxBoxes_Checked(object sender, RoutedEventArgs e)
        {
            bool check = true;
            filterEmployees.Clear();
            lbxEmployeeLists.ItemsSource = null;

            if (cboxFullTime.IsChecked == true && cboxPartTime.IsChecked == true) // if both are checked
            {
                lbxEmployeeLists.ItemsSource = employees.OrderBy(c => c.LastName); 
            }          
            else
            {              
                if (cboxFullTime.IsChecked == true )
                {
                    check = true;
                   
                }
                else if (cboxPartTime.IsChecked == true)
                {
                    check = false;
                }
                foreach(Employee employee in employees)
                { 
                    if (check)
                    {
                        if (employee as FullTimeEmployee != null)
                        {
                            filterEmployees.Add(employee);
                        }
                    }
                    if (!check)
                    {
                        if (employee as PartTimeEmployee != null)
                        {
                            filterEmployees.Add(employee);
                        }
                    }
                }
                lbxEmployeeLists.ItemsSource = filterEmployees.OrderBy(c => c.LastName);
            }          
        }

        private void cboxBoxes_UnChecked(object sender, RoutedEventArgs e)
        {
            bool check = true;
            filterEmployees.Clear();
            if (cboxFullTime.IsChecked == false && cboxPartTime.IsChecked == false) // if none are checked
            {
                lbxEmployeeLists.ItemsSource = null;
            }
            else
            {
                if (cboxFullTime.IsChecked == true)
                {
                    check = true;

                }
                else if (cboxPartTime.IsChecked == true)
                {
                    check = false;
                }
                foreach (Employee employee in employees)
                {
                    if (check)
                    {                        
                        if (employee as FullTimeEmployee != null)
                        {
                            filterEmployees.Add(employee);
                        }
                    }
                    if (!check)
                    {
                        if (employee as PartTimeEmployee != null)
                        {
                            filterEmployees.Add(employee);
                        }
                    }
                }
                lbxEmployeeLists.ItemsSource = filterEmployees.OrderBy(c => c.LastName);
            }
        }

        // Clear does just that, Clears all Fields and resets the radio buttons
        // Set a Method since i use it more than once
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        // Using more than once so decided that having a Method would be best
        // All it does is clear the enter txt fields
        private void ClearFields()
        {
            tbxFName.Clear();
            tbxLName.Clear();
            rbtnFT.IsChecked = false;
            rbtnPT.IsChecked = false;
            tbxSalary.Clear();
            tbxHourlyRate.Clear();
            tbxHrsWorked.Clear();
            tblkMonthlyPay.Text = ""; //just set it to blank manualy!!!
        }

        // wanted better code so added Tryparse()
        // handles anything but a number and even empty, for better code
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // first and last name will be used by both
            string firstName = tbxFName.Text;
            string lastName = tbxLName.Text.ToUpper();
            // if its Fulltime : FullTime has a salary
            if(rbtnFT.IsChecked == true)
            {              
                    string salarytxt = tbxSalary.Text;
                    decimal salary;
                    bool isNumber = decimal.TryParse(salarytxt, out salary);

                    if (isNumber)
                    {
                        FullTimeEmployee employee = new FullTimeEmployee(firstName, lastName, salary);
                        employees.Add(employee);
                        cboxFullTime.IsChecked = true;
                        cboxPartTime.IsChecked = false;
                        lbxEmployeeLists.ItemsSource = filterEmployees.OrderBy(c => c.LastName.ToUpper());
                    }                                                          
            }
            // if its PartTime : PartTime has a HoursWorked and HourlyRate
            if (rbtnPT.IsChecked == true)
            {
                string hRateText = tbxHourlyRate.Text;                
                decimal hourlyRate;
                bool isDecimal = decimal.TryParse(hRateText, out hourlyRate);
                string hWorkedText = tbxHrsWorked.Text;
                double hoursWorked;
                bool isDouble = double.TryParse(hWorkedText, out hoursWorked);
                
                if (isDecimal && isDouble)
                {
                    PartTimeEmployee employee = new PartTimeEmployee(firstName, lastName, hourlyRate, hoursWorked);
                    employees.Add(employee);
                    cboxFullTime.IsChecked = false;
                    cboxPartTime.IsChecked = true;
                    lbxEmployeeLists.ItemsSource = filterEmployees.OrderBy(c => c.LastName.ToUpper());
                }
            }
        }

        // Using Try Parse() here also!
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            // This is almost identical to AddButton()
            // There is enough important changes required that it made sense to remake this code 
            Employee selectedEmployee = lbxEmployeeLists.SelectedItem as Employee;
            if(selectedEmployee != null)
            {
                // first and last name will be used by both
                string firstName = tbxFName.Text;
                string lastName = tbxLName.Text.ToUpper();
                // FullTime has a salary
                if (rbtnFT.IsChecked == true)
                {
                    string salarytxt = tbxSalary.Text;
                    decimal salary;
                    bool isNumber = decimal.TryParse(salarytxt, out salary);

                    if (isNumber)
                    {
                        FullTimeEmployee employee = new FullTimeEmployee(firstName, lastName, salary);
                        employees.Add(employee);
                        employees.Remove(selectedEmployee);
                        cboxFullTime.IsChecked = true;
                        cboxPartTime.IsChecked = false;
                        lbxEmployeeLists.ItemsSource = filterEmployees.OrderBy(c => c.LastName.ToUpper());
                        // Remove will get rid of the selected Employee
                        // and add the Newly created Employee
                    }
                }
                // PartTime has a HoursWorked and HourlyRate
                if (rbtnPT.IsChecked == true)
                {
                    string hRateText = tbxHourlyRate.Text;
                    decimal hourlyRate;
                    bool isDecimal = decimal.TryParse(hRateText, out hourlyRate);
                    string hWorkedText = tbxHrsWorked.Text;
                    double hoursWorked;
                    bool isDouble = double.TryParse(hWorkedText, out hoursWorked);

                    if (isDecimal && isDouble)
                    {
                        PartTimeEmployee employee = new PartTimeEmployee(firstName, lastName, hourlyRate, hoursWorked);
                        employees.Add(employee);
                        employees.Remove(selectedEmployee);
                        cboxFullTime.IsChecked = false;
                        cboxPartTime.IsChecked = true;
                        lbxEmployeeLists.ItemsSource = filterEmployees.OrderBy(c => c.LastName.ToUpper());
                        // Remove will get rid of the selected Employee
                        // and add the Newly created Employee
                    }
                }               
            }
        }

        // delete will delete the employee that is currently selected
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = lbxEmployeeLists.SelectedItem as Employee;
            cboxFullTime.IsChecked = false;
            cboxPartTime.IsChecked = false;
            ClearFields();       
            employees.Remove(selectedEmployee);
            lbxEmployeeLists.ItemsSource = employees.OrderBy(c => c.LastName);
                         
        }
    }
}
