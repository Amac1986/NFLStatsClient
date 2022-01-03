using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using NFLStats.Model.Models;
using NFLStats.Services.Interfaces;
using NFLStats.Services.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NFLStats.Tests.ServicesTests
{    
    [TestClass]
    public class StatisticsServiceTests
    {
        [TestMethod]
        public void GetPagedRushingRecords_ReturnsRecordsSortedByYards_WhenArgumentsValid() 
        {
            var sut = CreateBasicSUT();
            var pageNumber = 1;
            var sortBy = "Yards";
            var playerFilter = "";


            var records = sut.GetPagedRushingRecords(pageNumber, sortBy, playerFilter);

            Assert.IsTrue(records.Any());
            Assert.AreEqual(365, records.Count());

        }

        private StatisticsService CreateBasicSUT() 
        {
            IDataStore dataStore = Mock.Of<IDataStore>(d => d.GetRushingRecords() == GetCollectionRushingRecords());
            var inMemorySettings = new Dictionary<string, string> {{ "ViewSettings:PageSize", "100"}};

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            return new StatisticsService(configuration, dataStore);
        }

        private IEnumerable<RushingRecord> GetCollectionRushingRecords() 
        {
            var path = "wwwroot/datafiles/rushing.json";

            return JsonConvert.DeserializeObject<IEnumerable<RushingRecord>>(File.ReadAllText(path));
        }
    }
}
