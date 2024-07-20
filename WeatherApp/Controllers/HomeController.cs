using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.ViewModels;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WeatherServices _weatherServices;

        public HomeController(ILogger<HomeController> logger, WeatherServices weatherServices)
        {
            _logger = logger;
            _weatherServices = weatherServices;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(WeatherViewModel model)
        {
            string apiKey = "aab013cd93f51a9e440646ffa4d9cbf4";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={model.city}&appid={apiKey}";
            return View(await _weatherServices.getWeather(url));
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
