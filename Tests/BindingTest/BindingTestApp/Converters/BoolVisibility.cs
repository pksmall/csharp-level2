using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace BindingTestApp.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    class BoolVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bool_value = System.Convert.ToBoolean(value);
            if (bool_value)
            {
                return Visibility.Visible;
            } 
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = System.Convert.ChangeType(value, typeof(Visibility));
            switch (visibility)
            {
                case Visibility.Hidden:
                    return false;
                case Visibility.Visible:
                    return true;
                default: throw new NotSupportedException($"Value {visibility} is not supported");
            }
        }
    }
}
