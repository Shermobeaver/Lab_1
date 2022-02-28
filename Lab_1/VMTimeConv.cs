using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using Class_Library;

namespace Lab_1
{
    public class VMTimeConv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if(value != null)
                {
                    VMTime val = (VMTime)value;
                    return $"WML_HA Coef: {val.WML_HA_Coef:0.00000000}, WML_EP Coef: {val.WML_EP_Coef:0.00000000}";
                }
                return "";
            }
            catch (Exception error)
            {
                MessageBox.Show($"Unexpected error: {error.Message}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "WML_HA Coef: ERROR, WML_EP Coef: ERROR";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new VMTime();
        }
    }
}
