using Microsoft.AspNetCore.Mvc;
using NFLStatsClient.ViewModels;
using System.Diagnostics;
using NFLStats.Services.Services;

namespace NFLStatsClient.Controllers
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
            var vm = _statisticsService.GetRushingRecords(1, "Yards",  true);
            return View();
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
    }
}