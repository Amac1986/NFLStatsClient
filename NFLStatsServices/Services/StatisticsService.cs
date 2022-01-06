using NFLStats.Model.Models;
using Microsoft.Extensions.Configuration;
using NFLStats.Services.Helpers;
using NFLStats.Services.Interfaces;

namespace NFLStats.Services.Services
{

    public class StatisticsService : IStatisticsService
    {
        private readonly IConfiguration _configuration;
        private readonly IDataStore _dataStore;

        public StatisticsService(IConfiguration configuration, IDataStore dataStore)
        {
            _configuration = configuration;
            _dataStore = dataStore;
        }
        public List<RushingRecord> GetPagedRushingRecords(int pageNumber, string sortBy, string playerFilter, bool ascending = false)
        {
            playerFilter = playerFilter ?? "";

            var pageSize = int.Parse(_configuration["ViewSettings:PageSize"]);

            return _dataStore.GetPagedRushingRecords(pageNumber, pageSize, sortBy, playerFilter, ascending).ToList();
        }

        public List<RushingRecord> GetRushingRecords(string sortBy, string playerFilter, bool ascending = false)
        {
            playerFilter = playerFilter ?? "";

            return _dataStore.GetRushingRecords(sortBy, playerFilter, ascending).ToList();
        }
    }
}
