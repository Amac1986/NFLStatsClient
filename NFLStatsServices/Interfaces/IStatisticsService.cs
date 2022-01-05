using NFLStats.Model.Models;


namespace NFLStats.Services.Interfaces
{
    public interface IStatisticsService
    {
        List<RushingRecord> GetPagedRushingRecords(int pageNumber, string sortBy, string playerFilter, bool ascending = false);

        List<RushingRecord> GetRushingRecords(string sortBy, string playerFilter, bool ascending = false);
    }
  
}
