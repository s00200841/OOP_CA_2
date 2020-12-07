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
    /// started 10:00 monday 07/12/2020
    /// Added as far as two check boxes and had to ask how to sort for individual clicks
    /// end: 1:00
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
            PartTimeEmployee pTE1 = new PartTimeEmployee("John", "Lennon", 12, 10);
            PartTimeEmployee pTE2 = new PartTimeEmployee("Abraham", "Johnson", 6, 10);

            FullTimeEmployee fTE1 = new FullTimeEmployee("Mike", "Zunt", 120);
            FullTimeEmployee fTE2 = new FullTimeEmployee("Mikey", "D", 240);

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
            PartTimeEmployee selectedEmployee = lbxEmployeeLists.SelectedItem as PartTimeEmployee;

            if (selectedEmployee != null)
            {
                // In here this will be used to fill the text boxes on the right with whichever employee we are on 
                // TODO : start this once i make the Texboxes and it is needed to have the information send into them
            }
        }

        private void cboxBoxes_Checked(object sender, RoutedEventArgs e)
        {
            int checker = 0;
            filterEmployees.Clear();
            lbxEmployeeLists.ItemsSource = null;

            // if both are checked
            if(cboxFullTime.IsChecked == true && cboxPartTime.IsChecked == true)
            {
                lbxEmployeeLists.ItemsSource = employees;
            }
            else
            {
                if (cboxFullTime.IsChecked == true)
                {
                    checker = 1;
                }
                else if (cboxPartTime.IsChecked == true)
                {
                    checker = 2;
                }
                foreach(Employee employee in employees)
                {
                    if (checker == 1)
                    {
                        // if full time
                        if(employee as FullTimeEmployee != null)
                        {
                            filterEmployees.Add(employee);
                        }
                    }
                    if (checker == 2)
                    {
                       if(employee as PartTimeEmployee != null)
                        {
                            filterEmployees.Add(employee);
                        }
                    }
                }
                lbxEmployeeLists.ItemsSource = filterEmployees;
            }
        }
    }
}
