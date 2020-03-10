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

namespace WpfAppEmployee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Department> departmentList;
        protected ObservableCollection<Employee> employeeList;
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();

            const int maxEmployee = 100;

            departmentList = new ObservableCollection<Department>
            {
                new Department(1, "aaa"),
                new Department(2, "bbb"),
                new Department(3, "ccc"),
                new Department(4, "ddd"),
            };

            employeeList = new ObservableCollection<Employee>();
            for (var i = 0; i < maxEmployee; i++)
            {
                if (i % 2 == 0)
                {
                    employeeList.Add(new FixedEmployee(
                        $"Student {i + 1}".ToString(),
                        random.Next(22, 65).ToString(),
                        departmentList[random.Next(departmentList.Count)].DepId,
                        departmentList,
                        random.Next(1000, 5000)));
                }
                else
                {
                    employeeList.Add(new TimeEmployee(
                        $"Student {i + 1}",
                        random.Next(22, 65).ToString(),
                        departmentList[random.Next(departmentList.Count)].DepId,
                        departmentList,
                        random.Next(25, 100)));
                }
            }

            //foreach(var emp in employeeList)
            //{
            //    MessageBox.Show(emp.Name + " " + emp.Department);
            //}
            employeeGrid.ItemsSource = employeeList;
        }

        private void OnExitHandler(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {          
            employeeList.Add(new TimeEmployee(
                $"New Student",
                random.Next(22, 65).ToString(),
                departmentList[random.Next(departmentList.Count)].DepId,
                departmentList,
                random.Next(25, 100)));
            if (employeeGrid.Items.Count > 0)
            {
                var border = VisualTreeHelper.GetChild(employeeGrid, 0) as Decorator;
                if (border != null)
                {
                    var scroll = border.Child as ScrollViewer;
                    if (scroll != null) scroll.ScrollToEnd();
                }
            }
        }

        protected EditDepartament subWindow;

        private void AddDepartament_Click(object sender, RoutedEventArgs e)
        {
            subWindow = new EditDepartament();
            subWindow.departmentGrid.ItemsSource = departmentList;
            subWindow.departmentList = departmentList;
            subWindow.DataChanged += SubWindow_DataChanged;
            subWindow.Show();
        }

        private void SubWindow_DataChanged(object sender, Department e)
        {
            departmentList.Add(e);
        }        
    }
}
