using NFLStats.Model.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;
using NFLStats.Services.Helpers;
using NFLStats.Services.Interfaces;

namespace NFLStats.Services.Services
{

    public class FileStatisticsService : IStatisticsService
    {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;

        public FileStatisticsService(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _memoryCache = memoryCache;
        }
        public List<RushingRecord> GetPagedRushingRecords(int pageNumber, string sortBy, string playerFilter, bool ascending = false)
        {

            var rushingRecords = ReadRecordsFromFile();

            var pageSize = int.Parse(_configuration["ViewSettings:PageSize"]);

            return rushingRecords
                .Where(r => r.PlayerName.ToLowerInvariant().Contains(playerFilter.ToLowerInvariant()))
                .SortRecords(sortBy, ascending)
                .PageRecords(pageSize, pageNumber)
                .ToList();
        }

        public List<RushingRecord> GetAllRushingRecords(string sortBy, bool ascending = false)
        {
            var rushingRecords = ReadRecordsFromFile();

            return rushingRecords
                .SortRecords(sortBy, ascending)
                .ToList();
        }

        public List<RushingRecord> GetFilteredRushingRecords(string sortBy, string playerFilter, bool ascending = false)
        {
            var rushingRecords = ReadRecordsFromFile();

            var pageSize = int.Parse(_configuration["ViewSettings:PageSize"]);

            return rushingRecords
                .Where(r => r.PlayerName.ToLowerInvariant().Contains(playerFilter.ToLowerInvariant()))
                .SortRecords(sortBy, ascending)
                .ToList();
        }

        private IEnumerable<RushingRecord> ReadRecordsFromFile()
        {
            if (!_memoryCache.TryGetValue("RushingRecords", out IEnumerable<RushingRecord> records))
            {
                var path = _configuration["DataSettings:Statistics:RushingFile"];

                records = JsonConvert.DeserializeObject<IEnumerable<RushingRecord>>(File.ReadAllText(path));

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(1));

                _memoryCache.Set("RushingRecords", records, cacheEntryOptions);
            }

            return records;
        }
    }
}
