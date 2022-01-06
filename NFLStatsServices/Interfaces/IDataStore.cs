using NFLStats.Model.Models;

namespace NFLStats.Services.Interfaces
{
    public interface IDataStore
    {
        IEnumerable<RushingRecord> GetRushingRecords(string sortBy, string playerFilter, bool ascending = false);

        IEnumerable<RushingRecord> GetPagedRushingRecords(int pageNumber, int pageSize, string sortBy, string playerFilter, bool ascending = false);
    }
}
