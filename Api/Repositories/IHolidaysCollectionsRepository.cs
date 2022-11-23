using MyHolidays.Models;

namespace MyHolidays.Repositories
{
    public interface IHolidaysCollectionsRepository
    {
        Task Insert(HolidaysCollection holidaysCollection);
        Task<List<HolidaysCollection>> Search(string name, int pageSize, int page);
        Task<List<HolidaysCollection>> GetMany(HashSet<string> holidaysCollectionsNames);
    }
}