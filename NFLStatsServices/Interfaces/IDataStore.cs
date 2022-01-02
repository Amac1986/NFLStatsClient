using NFLStats.Model.Models;

namespace NFLStats.Services.Interfaces
{
    public interface IDataStore
    {
        IEnumerable<RushingRecord> GetRushingRecords();
    }
}
