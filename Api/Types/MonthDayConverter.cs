using System.ComponentModel;
using System.Globalization;

namespace MyHolidays.Types
{
    #pragma warning disable CS8765
    #pragma warning disable CS8603
    public class MonthDayConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, 
            CultureInfo culture, object value)
        {
            if (value is string)
            {
                if (MonthDay.TryParse((string)value, out var result))
                {
                    return result;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}