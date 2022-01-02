using Microsoft.AspNetCore.Mvc;
using NFLStats.Client.ViewModels;
using System.Diagnostics;
using System.Text;
using NFLStats.Services.Interfaces;
using NFLStats.Model.Models;

namespace NFLStats.Client.Controllers
{
    public class NFLStatsController : Controller
    {
        private readonly ILogger<NFLStatsController> _logger;
        private readonly IStatisticsService _statisticsService;

        public NFLStatsController(ILogger<NFLStatsController> logger, IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var vm = GetRushStatisticsViewModel();
            return View("Rushing", vm);
        }

        //public IActionResult PassingHome()
        //{
        //    var vm = GetRushStatisticsViewModel();
        //    return View("Passing", vm);
        //}

        //[HttpPost]
        //public IActionResult GetPassingStats()
        //{
        //    var vm = GetRushStatisticsViewModel(model);
        //    return PartialView("StatsPartials/_PassingTable", vm);
        //}

        [HttpPost]
        public IActionResult GetRushingStats(RushingViewModel model)
        {

            var records = _statisticsService.GetPagedRushingRecords(model.PageNumber, model.SortBy, model.PlayerNameFilter, model.SortAscending);
            return PartialView("StatsPartials/_StatsTableData", records);

        }

        [HttpPost]
        public IActionResult DownloadFullRushingStats(RushingViewModel model)
        {

            var records = _statisticsService.GetAllRushingRecords(model.SortBy, model.SortAscending);

            var bytesFromFromCollection = GetCSVfromCollection(records);

            var fileName = $"NFLRushingStats_2019" + new Guid();

            return File(bytesFromFromCollection, "text/csv", fileName);
        }



        [HttpPost]
        public IActionResult DownloadPartialRushingStats(RushingViewModel model)
        {

            var records = _statisticsService.GetFilteredRushingRecords(model.SortBy, model.PlayerNameFilter, model.SortAscending);

            var bytesFromFromCollection = GetCSVfromCollection(records);

            var fileName = $"NFLRushingStats_2019_SortOn({model.SortBy})_FilteredBy({model.PlayerNameFilter})" + new Guid();

            return File(bytesFromFromCollection, "text/csv", fileName);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private RushingViewModel GetRushStatisticsViewModel()
        {
            var model = new RushingViewModel
            {
                StatTable = new StatTableViewModel(_statisticsService.GetPagedRushingRecords(1, "Yards", ""))
            };
            return model;
        }

        private RushingViewModel GetRushStatisticsViewModel(RushingViewModel model)
        {
            var returnModel = new RushingViewModel
            {
                PageNumber = model.PageNumber,
                SortAscending = model.SortAscending,
                PlayerNameFilter = model.PlayerNameFilter,
                SortBy = model.SortBy,
                StatTable = new StatTableViewModel(_statisticsService.GetPagedRushingRecords(model.PageNumber, model.SortBy, model.PlayerNameFilter, model.SortAscending))
            };

            return returnModel;
        }

        private byte[] GetCSVfromCollection<T> (IEnumerable<T>  records) where T : Record
        {
            var sb = new StringBuilder();
            
            sb.AppendLine(records.FirstOrDefault().GetCSVHead());

            foreach (var record in records)
            {
                sb.AppendLine(record.ToCSV());
            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}