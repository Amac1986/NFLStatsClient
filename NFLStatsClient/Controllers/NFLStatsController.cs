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
            var vm = new RushingViewModel(_statisticsService.GetPagedRushingRecords(1, "Yards", ""));
            return View("Rushing", vm);
        }

        [HttpPost]
        public IActionResult GetRushingStats(RushingViewModel model)
        {

            var records = _statisticsService.GetPagedRushingRecords(model.PageNumber, model.SortBy, model.PlayerNameFilter, model.SortAscending);
            return PartialView("StatsPartials/_StatsTableData", records);

        }

        [HttpPost]
        public IActionResult DownloadRushingStats(RushingViewModel model, bool ignoreFilter = false)
        {
            if (ignoreFilter) model.PlayerNameFilter = "";

            var records = _statisticsService.GetRushingRecords(model.SortBy, model.PlayerNameFilter, model.SortAscending);

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