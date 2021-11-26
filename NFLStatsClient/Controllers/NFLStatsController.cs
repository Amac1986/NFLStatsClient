using Microsoft.AspNetCore.Mvc;
using NFLStatsClient.ViewModels;
using System.Diagnostics;

namespace NFLStatsClient.Controllers
{
    public class NFLStatsController : Controller
    {
        private readonly ILogger<NFLStatsController> _logger;

        public NFLStatsController(ILogger<NFLStatsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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