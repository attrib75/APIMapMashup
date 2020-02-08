using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MapMashup.Models;
using MapMashup.DAL;
using Microsoft.Extensions.Options;

namespace MapMashup.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BingAPIClient bingAPIClient;

        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            AppSettings = appSettings?.Value;
            bingAPIClient = new BingAPIClient(AppSettings.Host, AppSettings.BingAPIKey);
        }

        public AppSettings AppSettings { get; private set; }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            return View("Index", AppSettings.AzureMapsKey);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> SearchRestaurants(string searchInput)
        {
            if (!string.IsNullOrEmpty(searchInput))
            {
                try
                {
                    var results = await bingAPIClient.GetBusinesses(searchInput);
                    return Json(results);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Please fill out the form.");
            }

            return Json(string.Empty);
        }
    }
}