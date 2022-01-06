using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NFLStats.Model.Models;
using NFLStats.Services.Helpers;
using NFLStats.Services.Interfaces;

namespace NFLStats.Persistence
{
    public class FileDataStore : IDataStore
    {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;

        public FileDataStore(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _memoryCache = memoryCache;
        }    

        public IEnumerable<RushingRecord> GetRushingRecords(string sortBy, string playerFilter, bool ascending = false)
        {
            return LoadRecords()
                .Where(r => r.PlayerName.ToLowerInvariant().Contains(playerFilter.ToLowerInvariant()))
                .SortRecords(sortBy, ascending)
                .ToList();
        }

        public IEnumerable<RushingRecord> GetPagedRushingRecords(int pageNumber, int pageSize, string sortBy, string playerFilter, bool ascending = false) 
        {
            return LoadRecords()
                .Where(r => r.PlayerName.ToLowerInvariant().Contains(playerFilter.ToLowerInvariant()))
                .SortRecords(sortBy, ascending)
                .PageRecords(pageSize, pageNumber)
                .ToList();
        }

        private IEnumerable<RushingRecord> LoadRecords() 
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