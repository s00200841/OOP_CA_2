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
    /// started monday 07/12/2020 start: 10:00 end: 1:00 *** start: 2:00 end:
    /// Added as far as two check boxes and had to ask how to sort for individual clicks need to optimise next before moving on
    /// On Part 13 Going fairly good sofar
    /// {Clear() pt 14 is added}, pt 13 need Add Update and Delete 
    public partial class MainWindow : Window
    {

        //ObservableCollection<PartTimeEmployee> pTEmployees = new ObservableCollection<PartTimeEmployee>();
       // ObservableCollection<FullTimeEmployee> fTEmployees = new ObservableCollection<FullTimeEmployee>();
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        ObservableCollection<Employee> filterEmployees = new ObservableCollection<Employee>();
        //ObservableCollection<PartTimeEmployee> filterPTEmployees = new ObservableCollection<PartTimeEmployee>();
        //ObservableCollection<FullTimeEmployee> filterFTEmployees = new ObservableCollection<FullTimeEmployee>();

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

            // Started out tyring to figure out how i would start adding employees
            //pTEmployees.Add(pTE1);
            //pTEmployees.Add(pTE2);

            //fTEmployees.Add(fTE1);
            //fTEmployees.Add(fTE2);

            //lbxEmployeeLists.ItemsSource = pTEmployees;
            //lbxEmployeeLists.ItemsSource = fTEmployees;
        }

        private void lbxEmployeeLists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee selectedEmployee = lbxEmployeeLists.SelectedItem as Employee;

            if (selectedEmployee != null)
            {
                // In here this will be used to fill the text boxes on the right with whichever employee we are on 
                // TODO : Might need more here, other textboxes etc, might also need an if for the salary since its fulltime only
                tbxFName.Text = selectedEmployee.FirstName;
                tbxLName.Text = selectedEmployee.LastName;
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
            if (cboxFullTime.IsChecked == false && cboxPartTime.IsChecked == false)
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
    }
}
