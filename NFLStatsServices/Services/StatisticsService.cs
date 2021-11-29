using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NFLStats.Model.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;

namespace NFLStats.Services.Services
{
    public interface IStatisticsService
    {
        List<RushingRecord> GetRushingRecords(int pageNumber, string sortBy);
    }

    public class FileStatisticsService : IStatisticsService
    {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;

        public FileStatisticsService(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _memoryCache = memoryCache;
        }
        public List<RushingRecord> GetRushingRecords(int pageNumber, string sortBy)
        {
            if (!_memoryCache.TryGetValue("RushingRecords", out IEnumerable<RushingRecord> records))
            {
                var path = _configuration["DataSettings:Statistics:RushingFile"];

                records = JsonConvert.DeserializeObject<IEnumerable<RushingRecord>>(File.ReadAllText(path));

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(1));

                _memoryCache.Set("RushingRecords", records, cacheEntryOptions);
            }

            var rushingRecords = records;

            var pageSize = int.Parse(_configuration["ViewSettings:PageSize"]);

            return SortRecords(rushingRecords, sortBy, pageSize, pageNumber).ToList() ?? new List<RushingRecord>();
        }

        private IEnumerable<T> SortRecords<T>(IEnumerable<T> unsorted, string sortBy, int pageSize, int pageNumber)
        {
            if (unsorted is null || !unsorted.Any()) return new List<T>();

            var skipRecords = (pageNumber - 1) * pageSize;

            return unsorted.OrderByDescending(r => r.GetType().GetProperty(sortBy).Name)
                .Skip(skipRecords)
                .Take(pageSize);

        }
    }
}
