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
using System.Windows.Shapes;

namespace WpfAppEmployee
{
    /// <summary>
    /// Interaction logic for EditDepartament.xaml
    /// </summary>
    public partial class EditDepartament : Window
    {
        public ObservableCollection<Department> departmentList { get; set; }
        public delegate void DataChangedEventHandler(object sender, Department e);
        public event DataChangedEventHandler DataChanged;

        public EditDepartament()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataChangedEventHandler handler = DataChanged;

            var index = departmentList[departmentList.Count - 1].DepId + 1;
            handler?.Invoke(this, new Department(index, "new dep"));

            if (departmentGrid.Items.Count > 0)
            {
                var border = VisualTreeHelper.GetChild(departmentGrid, 0) as Decorator;
                if (border != null)
                {
                    var scroll = border.Child as ScrollViewer;
                    if (scroll != null) scroll.ScrollToEnd();
                }
            }
        }
    }
}
