using MyHolidays.Models;
using MyHolidays.Repositories;

namespace MyHolidays.UseCases
{
    public class CheckHolidaysUseCase : ICheckHolidaysUseCase
    {
        private readonly IHolidaysCollectionsRepository HolidaysCollectionsRepository;

        public CheckHolidaysUseCase(IHolidaysCollectionsRepository holidaysCollectionsRepository) {
            HolidaysCollectionsRepository = holidaysCollectionsRepository;
        }

        public async Task<IEnumerable<string>> ExecuteAsync(HashSet<string> holidaysCollectionsNames, DateTime? date)
        {
            var holidaysCollections = await HolidaysCollectionsRepository.GetMany(holidaysCollectionsNames);

            var holidays = Execute(holidaysCollections, date);

            return holidays;
        }
        
        public IEnumerable<string> Execute(List<HolidaysCollection> holidaysCollections, DateTime? date)
        {
            date ??= DateTime.Now;
            
            var holidays = new List<string>();

            holidaysCollections.ForEach(hc => {
                var holiday = hc.GetHoliday(date.Value);

                if (holiday is not null)
                {
                    holidays.Add(holiday);
                }
            });

            return holidays;
        }
    }
}