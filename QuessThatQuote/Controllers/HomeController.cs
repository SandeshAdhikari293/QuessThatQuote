using Microsoft.AspNetCore.Mvc;
using QuessThatQuote.Models;
using System.Diagnostics;
using RestSharp;
using System.Text.Json;

namespace QuessThatQuote.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var client = new RestClient($"https://api.breakingbadquotes.xyz/v1/quotes/3");
            var request = new RestRequest();
            RestResponse response = await client.ExecuteAsync(request);

            List<BbQuote> bbQuote = BbQuote.FromJson(response.Content);


            return View("Index", bbQuote);
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