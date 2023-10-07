using Microsoft.AspNetCore.Mvc;
using QuessThatQuote.Models;
using RestSharp;
using System.Diagnostics;

namespace QuessThatQuote.Controllers
{
    public class BreakingBadController : Controller
    {

        public BreakingBadController() {


        }


        public IActionResult Play()
        {

            RestClient client = new RestClient($"https://api.breakingbadquotes.xyz/v1/quotes/" + 20);
            RestRequest request = new RestRequest();
            RestResponse response = client.Execute(request);
            return View("Play", response.Content);
        }

    }
}
