using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BindingTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2
    {
        public MainWindow2()
        {
            InitializeComponent();

            var horizontal_binding = new Binding();
            horizontal_binding.ElementName = "HorizontalSlider";
            horizontal_binding.Path = new PropertyPath("Value");

            HorizontalValue.SetBinding(TextBlock.TextProperty, horizontal_binding);

            var vartical_binding = new Binding();
            vartical_binding.ElementName = "VerticalSlider";
            vartical_binding.Path = new PropertyPath("Value");

            VerticalValue.SetBinding(TextBlock.TextProperty, vartical_binding);
        }
    }    
}
