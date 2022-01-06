using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NFLStats.Client.Controllers;
using NFLStats.Client.ViewModels;
using NFLStats.Services.Interfaces;
using NFLStats.Tests.PersistenceTests;

namespace NFLStats.Tests
{
    [TestClass]
    public class NFLStatsControllerTests
    {
        [TestMethod]
        public void IndexGet_ReturnsViewResult()
        {
            IStatisticsService mockService = Mock.Of<IStatisticsService>(x => x.GetPagedRushingRecords(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()) == FileDataStoreTests.GetCollectionRushingRecords());

            var controller = new NFLStatsController(mockService);

            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void GetRushingStatsPost_ReturnsPartialViewResult()
        {
            IStatisticsService mockService = Mock.Of<IStatisticsService>(x => x.GetPagedRushingRecords(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()) == FileDataStoreTests.GetCollectionRushingRecords());

            var controller = new NFLStatsController(mockService);

            var vm = BuildRushingViewModel();

            var result = controller.GetRushingStats(vm);

            Assert.IsInstanceOfType(result, typeof(PartialViewResult));
        }

        [TestMethod]
        public void DownloadFullRushingStats_ReturnsFileContentResult()
        {
            IStatisticsService mockService = Mock.Of<IStatisticsService>(x => x.GetRushingRecords(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()) == FileDataStoreTests.GetCollectionRushingRecords());

            var controller = new NFLStatsController(mockService);

            var vm = BuildRushingViewModel();

            var result = controller.DownloadRushingStats(vm, true);

            Assert.IsInstanceOfType(result, typeof(FileContentResult));
        }

        [TestMethod]
        public void DownloadPartialRushingStats_ReturnsFilteredFileContentResult()
        {
            IStatisticsService mockService = Mock.Of<IStatisticsService>(x => x.GetRushingRecords(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()) == FileDataStoreTests.GetCollectionRushingRecords());

            var controller = new NFLStatsController(mockService);

            var vm = BuildRushingViewModel();

            var result = controller.DownloadRushingStats(vm);

            Assert.IsInstanceOfType(result, typeof(FileContentResult));
        }

        private RushingViewModel BuildRushingViewModel() 
        {
            return new RushingViewModel()
            {
                SortBy = "Yards",
                SortAscending = false,
                PlayerNameFilter = "",
                PageNumber = 1,
            };
        }
    }
}