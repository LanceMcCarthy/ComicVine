using System;
using System.Globalization;
using Xamarin.Forms;

namespace ComicVine.Portable.Converters
{
    class SecondsToTimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int seconds)
            {
                return TimeSpan.FromSeconds(seconds);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
