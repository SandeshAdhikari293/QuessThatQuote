using com.sun.security.ntlm;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuessThatQuote.Data;
using QuessThatQuote.Models;
using RestSharp;
using System.Diagnostics;

namespace QuessThatQuote.Controllers
{
    public class Brooklyn99Controller : Controller
    {
        readonly ApplicationDbContext _context;
        //string gameType = "Brooklyn%20Nine-Nine";
        public Brooklyn99Controller(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<IActionResult> Play(string game)
        {
            List<string> authors = new List<string>();

            RestClient client = new RestClient("https://quotes.alakhpc.com/quotes/11?show="+ game.Replace(" ", "%20") + "&short=true");
            RestRequest request = new RestRequest();
            //request.AddHeader("X-RapidAPI-Key", "a2fa7c695cmsh6b55c1d38835d43p194265jsn1cf99a6eb0ca");
            //request.AddHeader("X-RapidAPI-Host", "movie-and-tv-shows-quotes.p.rapidapi.com");
            RestResponse response = null;

            while (authors.Count < 4)
            {
                authors.Clear();
                response = client.Execute(request);

                dynamic json = JsonConvert.DeserializeObject(response.Content);

                for(int i = 0; i < 10; i++)
                {
                    string name = json[i].character;
                    if (!authors.Contains(name))
                    {
                        authors.Add(name);  
                    }
                }
                Debug.WriteLine(authors.Count);
            }

            QuoteViewModel quoteViewModel = new QuoteViewModel();
            quoteViewModel.Json = response.Content;
            quoteViewModel.LeaderboardEntry = new LeaderboardEntry();
            quoteViewModel.LeaderboardEntry.GameType = game;

            return View("Play", quoteViewModel);
        }

        [HttpPost]
        public IActionResult Save(LeaderboardEntry entry)
        {

            //entry.GameType = gameType;
            _context.LeaderboardEntry.Add(entry);
            _context.SaveChanges();

            return View("Leaderboard", _context.LeaderboardEntry.ToList().OrderByDescending(s => s.Score));
        }
    }
}
