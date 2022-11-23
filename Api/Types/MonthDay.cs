using System.ComponentModel;

namespace MyHolidays.Types
{
    [TypeConverter(typeof(MonthDayConverter))]
    public struct MonthDay
    {
        const string BAR = "/";
        const string ERROR_MESSAGE_WRONGF_FORMAT = "Wrong MonthDay format";
        private string _value { get; set; }

        private MonthDay(string value)
        {
            _value = value;
        }

        public static MonthDay Parse(string value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException(ERROR_MESSAGE_WRONGF_FORMAT);
        }

        public static bool TryParse(string value, out MonthDay MonthDay)
        {
            var year = DateTime.Now.Year;
            var isOk = DateOnly.TryParse(value + BAR + year, out var r);
            
            MonthDay = new MonthDay(r.Month + BAR + r.Day);

            if (!isOk)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
            => _value;

        public static implicit operator MonthDay(string input)
            => Parse(input);

        public static implicit operator string(MonthDay input)
            => input.ToString();
        
        public static implicit operator MonthDay(DateTime input)
            => Parse(input.Month + BAR + input.Day);
    }
}