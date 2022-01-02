using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NFLStats.Client.ViewModels;
using NFLStats.Services.Interfaces;

namespace NFLStats.Tests
{
    [TestClass]
    public class NFLStatsControllerTests
    {
        [TestMethod]
        public void IndexGet_ReturnsViewResult()
        {
            var vm = new RushingViewModel() {
                
            };
            var mockService = new Mock<IStatisticsService>();
            //mockService.Setup(x => x.GetPagedRushingRecords(0, "", "", false)).Returns(GetFilteredCollection());
            Assert.Inconclusive();
        }

        [TestMethod]
        public void GetRushingStatsPost_ReturnsPartialViewResult()
        {

        }

        [TestMethod]
        public void DownloadFullRushingStats_ReturnsFileContentResult()
        {

        }

        [TestMethod]
        public void DownloadPartialRushingStats_ReturnsFilteredFileContentResult()
        {

        }
    }
}