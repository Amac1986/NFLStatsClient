using Microsoft.AspNetCore.Mvc;
using NFLStats.Client.ViewModels;
using System.Diagnostics;
using NFLStats.Services.Services;

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

        //[HttpPost]
        //public IActionResult GetStats(StatisticsViewModel model)
        //{
            

        //}

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
                RushingRecords = _statisticsService.GetRushingRecords(1, "Yards")
            };
            return model;
        }
    }
}