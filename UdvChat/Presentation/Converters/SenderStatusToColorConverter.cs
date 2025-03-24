using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvChat.Presentation.Converters
{
    class SenderStatusToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var colorResource = Application.Current.Resources.MergedDictionaries.FirstOrDefault() as ResourceDictionary;
            if (value is bool isSender)
            {
                if (isSender)
                    return colorResource["Secondary"] as Color;
            }
            return colorResource["Gray300"] as Color;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
