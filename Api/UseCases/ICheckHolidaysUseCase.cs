using MyHolidays.Models;

namespace MyHolidays.UseCases
{
    public interface ICheckHolidaysUseCase
    {
        IEnumerable<string> Execute(List<HolidaysCollection> holidaysCollections, DateTime? date);
        Task<IEnumerable<string>> ExecuteAsync(HashSet<string> holidaysCollectionsNames, DateTime? date);
    }
}