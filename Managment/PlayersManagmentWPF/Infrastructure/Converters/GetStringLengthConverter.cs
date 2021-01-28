using System;
using System.Globalization;
using System.Windows.Data;

namespace PlayersManagmentWPF.Infrastructure.Converters
{
    public class GetStringLengthConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            var str = value?.ToString();
            if (str is null) return null;

            return str.Length;
        }

        public object ConvertBack(object value, Type t, object p, CultureInfo c) =>
            throw new NotSupportedException("Преобразование из числа в строку не поддерживается!");
    }
}
