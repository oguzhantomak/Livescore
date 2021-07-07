using Livescore.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Livescore.Business.Abstract;
using Livescore.Entity;

namespace Livescore.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMatchService _matchService;

        public HomeController(ILogger<HomeController> logger, IMatchService matchService)
        {
            _logger = logger;
            this._matchService = matchService;
        }


        public async Task<ActionResult> Index()
        {
           // 7 gün önceki ve 7 gün sonraki maçları çek
           var matches = await _matchService.TodaysMatches();
            return View(matches);
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
