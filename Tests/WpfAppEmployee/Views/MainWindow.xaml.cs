using System.Windows;

namespace WpfAppEmployee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnExitHandler(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {          
        }

        protected EditDepartament subWindow;

        private void AddDepartament_Click(object sender, RoutedEventArgs e)
        {
            subWindow = new EditDepartament();
            subWindow.Show();
        }
    }
}
