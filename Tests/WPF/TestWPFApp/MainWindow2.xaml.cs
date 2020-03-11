using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace TestWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Choose file for edit",
                Filter = "Text files (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() != true) return;

            var fileName = openFileDialog.FileName;

            if (!File.Exists(fileName))
            {
                MessageBox.Show("File not exists.");
                return;
            }

            var fileText = File.ReadAllText(fileName);

            TextEditor.Text = fileText;

        }

        private void OnExitHandler(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
