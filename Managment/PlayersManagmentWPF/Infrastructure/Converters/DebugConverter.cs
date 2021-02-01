using System;
using System.Globalization;
using System.Windows.Data;
using System.Diagnostics;

namespace PlayersManagmentWPF.Infrastructure.Converters
{
    public class DebugConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            Debugger.Break();
            return value;
        }

        public object ConvertBack(object value, Type t, object p, CultureInfo c)
        {
            Debugger.Break();
            return value;
        }
    }
}
