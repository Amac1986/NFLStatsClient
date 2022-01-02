using NFLStats.Model.Models;


namespace NFLStats.Services.Interfaces
{
    public interface IStatisticsService
    {
        List<RushingRecord> GetPagedRushingRecords(int pageNumber, string sortBy, string playerFilter, bool ascending = false);

        List<RushingRecord> GetAllRushingRecords(string sortBy, bool ascending = false);

        List<RushingRecord> GetFilteredRushingRecords(string sortBy, string playerFilter, bool ascending = false);
    }
  
}
