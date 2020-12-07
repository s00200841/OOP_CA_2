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
    /// {Clear() pt 14 is added}, pt 13 need Add Update and Delete 
    /// Add() works 
    /// TODO: cboxes are both off at start but list shows -  will not show if 
    /// Have a Lot of work piling up and have the free time today so i real went through quite a bit
    /// Im Preaty much done on day one but i will leave the sending till i give it a day or two and review my code of any further updating / fixing
    /// Sure Ill find something i could add or that i have missed
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
            PartTimeEmployee pTE1 = new PartTimeEmployee("John", "Lennon", 10, 32);
            PartTimeEmployee pTE2 = new PartTimeEmployee("Abraham", "Johnson", 10, 24);

            FullTimeEmployee fTE1 = new FullTimeEmployee("Mike", "Zunt", 1200);
            FullTimeEmployee fTE2 = new FullTimeEmployee("Mikey", "D", 2400);

            employees.Add(pTE1);
            employees.Add(pTE2);
            employees.Add(fTE1);
            employees.Add(fTE2);

            lbxEmployeeLists.ItemsSource = employees;

        }

        private void lbxEmployeeLists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee selectedEmployee = lbxEmployeeLists.SelectedItem as Employee;

            if (selectedEmployee != null)
            {
                // In here this will be used to fill the text boxes on the right with whichever employee we have selected
                // also update and delete will rely on this
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
        // need the check/uncheck but might need to recheck code and refactor at some point
        // TODO: recheck both methods
        private void cboxBoxes_Checked(object sender, RoutedEventArgs e)
        {
            bool check = true;
            filterEmployees.Clear();
            lbxEmployeeLists.ItemsSource = null;

            if (cboxFullTime.IsChecked == true && cboxPartTime.IsChecked == true) // if both are checked
            {
                lbxEmployeeLists.ItemsSource = employees;
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
                lbxEmployeeLists.ItemsSource = filterEmployees;
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
                lbxEmployeeLists.ItemsSource = filterEmployees;
            }
        }

        // Clear does just that, Clears all Fields and resets the radio buttons
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbxFName.Clear();
            tbxLName.Clear();
            rbtnFT.IsChecked = false;
            rbtnPT.IsChecked = false;
            tbxSalary.Clear();
            tbxHourlyRate.Clear();
            tbxHrsWorked.Clear();
            tblkMonthlyPay.Text = ""; // Not sure about this one, just set it to blank manualy!!!
        }

        // wanted better code so added Tryparse()
        // handles empty and anything but a number for better code
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // first and last name will be used by both
            string firstName = tbxFName.Text;
            string lastName = tbxLName.Text;
            // FullTime has a salary
            if(rbtnFT.IsChecked == true)
            {              
                    string salarytxt = tbxSalary.Text;
                    decimal salary;
                    bool isNumber = decimal.TryParse(salarytxt, out salary);

                    if (isNumber)
                    {
                        FullTimeEmployee employee = new FullTimeEmployee(firstName, lastName, salary);
                        employees.Add(employee);
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
                }
            }           
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            // This is almost identical to AddButton()
            // There is enough important changes required that it made sense to remake this code 
            Employee selectedEmployee = lbxEmployeeLists.SelectedItem as Employee;
            if(selectedEmployee != null)
            {
                // first and last name will be used by both
                string firstName = tbxFName.Text;
                string lastName = tbxLName.Text;
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
                        // Remove will get rid of the selected Employee as i cuold no find a replace i went with this option
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
                        // Remove will get rid of the selected Employee as i cuold no find a replace i went with this option
                    }
                }
            }       
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = lbxEmployeeLists.SelectedItem as Employee;
            employees.Remove(selectedEmployee);
        }
    }
}
