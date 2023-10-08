using Microsoft.AspNetCore.Mvc;
using QuessThatQuote.Data;
using QuessThatQuote.Models;
using RestSharp;
using System.Diagnostics;
using System.Web;

namespace QuessThatQuote.Controllers
{
    public class BreakingBadController : Controller
    {

        readonly ApplicationDbContext _context;
        public BreakingBadController(ApplicationDbContext applicationDbContext) {
            _context = applicationDbContext;
        }


        public IActionResult Play()
        {

            RestClient client = new RestClient($"https://api.breakingbadquotes.xyz/v1/quotes/" + 100);
            RestRequest request = new RestRequest();
            RestResponse response = client.Execute(request);

            QuoteViewModel quoteViewModel = new QuoteViewModel();
            quoteViewModel.Json = response.Content;

            return View("Play", quoteViewModel);
        }

        [HttpPost]
        public IActionResult Save(LeaderboardEntry entry)
        {

            entry.GameType = "BreakingBad";
            _context.LeaderboardEntry.Add(entry);
            _context.SaveChanges();

            return View("Leaderboard", _context.LeaderboardEntry.ToList().OrderByDescending(s => s.Score));
        }

    }
}
