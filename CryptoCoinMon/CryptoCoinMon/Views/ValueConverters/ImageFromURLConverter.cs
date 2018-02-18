using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace CryptoCoinMon.Views.ValueConverters
{
    public class ImageFromURLConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            var source = value as string;

            //if the value passed does not cast to a string, 
            //Dont continue and return Null
            if (string.IsNullOrEmpty(source))
                return null;

            return ImageSource.FromUri(new Uri(source));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
