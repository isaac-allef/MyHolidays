using MyHolidays.Types;

namespace MyHolidays.Models
{
    public class HolidaysCollection
    {
        public HolidaysCollection(string name, Dictionary<MonthDay, string>? holidays)
        {
            Name = name;
            Holidays = holidays is null ? new Dictionary<MonthDay, string>() : holidays;
        }

        public string Name { get; set; }
        public Dictionary<MonthDay, string> Holidays { get; private set; }

        public void AddHoliday(MonthDay date, string description)
        {
            Holidays.Add(date, description);
        }

        public string? GetHoliday(MonthDay date)
        {
            if (Holidays.ContainsKey(date))
            {
                return Holidays[date];
            }
            return null;
        }
    }
}