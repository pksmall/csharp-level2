using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitEventHandler(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenFlieHandler(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Choose file for edit",
                Filter = "Text files (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            var fileName = openFileDialog.FileName;

            if (!File.Exists(fileName))
            {
                MessageBox.Show("File not exists.");
                return;
            }

            var fileText = File.ReadAllText(fileName);

            TextBox.Text = fileText;
        }
    }
}
