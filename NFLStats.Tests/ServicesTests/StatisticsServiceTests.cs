using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFLStats.Services.Interfaces;

namespace NFLStats.Tests.ServicesTests
{    
    [TestClass]
    public class StatisticsServiceTests
    {
        [TestMethod]
        public void GetPagedRushingRecords_ReturnsRecordsSortedByYards_ByDefault_WhenArgumentsValid() 
        {
            var dataStore = new Moq.Mock<IDataStore>();
            //dataStore.Setup(x => x.GetRushingRecords).Returns()
        }

        //private List<RushingRecord> GetCollection
    }
}
