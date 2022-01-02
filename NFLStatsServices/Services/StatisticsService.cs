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

            var rushingRecords = _dataStore.GetRushingRecords();

            var pageSize = int.Parse(_configuration["ViewSettings:PageSize"]);

            return rushingRecords
                .Where(r => r.PlayerName.ToLowerInvariant().Contains(playerFilter.ToLowerInvariant()))
                .SortRecords(sortBy, ascending)
                .PageRecords(pageSize, pageNumber)
                .ToList();
        }

        public List<RushingRecord> GetAllRushingRecords(string sortBy, bool ascending = false)
        {
            var rushingRecords = _dataStore.GetRushingRecords();

            return rushingRecords
                .SortRecords(sortBy, ascending)
                .ToList();
        }

        public List<RushingRecord> GetFilteredRushingRecords(string sortBy, string playerFilter, bool ascending = false)
        {
            var rushingRecords = _dataStore.GetRushingRecords();

            var pageSize = int.Parse(_configuration["ViewSettings:PageSize"]);

            return rushingRecords
                .Where(r => r.PlayerName.ToLowerInvariant().Contains(playerFilter.ToLowerInvariant()))
                .SortRecords(sortBy, ascending)
                .ToList();
        }
    }
}
