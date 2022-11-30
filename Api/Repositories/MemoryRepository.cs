using MyHolidays.Models;

namespace MyHolidays.Repositories
{
    public class MemoryRepository : IHolidaysCollectionsRepository
    {
        private static Dictionary<string, HolidaysCollection> memory = new Dictionary<string, HolidaysCollection>();

        public async Task Insert(HolidaysCollection holidaysCollection)
        {
            await Task.Run(() => memory.Add(holidaysCollection.Name, holidaysCollection));
        }

        public async Task<List<HolidaysCollection>> Search(string name, int pageSize, int page)
        {
            var holidaysCollections = memory.Where(m => m.Value.Name.Contains(name)).Take(pageSize).Skip(page-1).Select(m => m.Value).ToList();
            return await Task.Run(() => holidaysCollections);
        }

        public async Task<List<HolidaysCollection>> GetMany(HashSet<string> holidaysCollectionsNames)
        {
            var holidaysCollections = new List<HolidaysCollection>();

            foreach (var name in holidaysCollectionsNames.Where(name => memory.ContainsKey(name)))
            {
                holidaysCollections.Add(memory[name]);
            }

            return await Task.Run(() => holidaysCollections);
        }
    }
}