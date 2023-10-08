using Microsoft.AspNetCore.Mvc;
using QuessThatQuote.Models;
using System.Diagnostics;
using RestSharp;
using System.Text.Json;
using QuessThatQuote.Data;

namespace QuessThatQuote.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _context = applicationDbContext;
        }

        public async Task<IActionResult> Index()
        {
            return View("Index");
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

        public IActionResult Leaderboard()
        {

            return View("Leaderboard", _context.LeaderboardEntry.ToList().OrderByDescending(s => s.Score));
        }
    }
}