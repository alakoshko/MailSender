using System;
using System.Globalization;
using System.Windows.Data;

namespace MailSender.Infrastructure
{
    class ServersUseSSlBooleanConverter : IValueConverter
    {
        private const string EnabledText = "Да";
        private const string DisabledText = "Нет";
        public static readonly ServersUseSSlBooleanConverter Instance = new ServersUseSSlBooleanConverter();

        private ServersUseSSlBooleanConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Equals(true, value)
                ? EnabledText
                : DisabledText;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Actually won't be used, but in case you need that
            return Equals(value, EnabledText);
        }
    }
}
