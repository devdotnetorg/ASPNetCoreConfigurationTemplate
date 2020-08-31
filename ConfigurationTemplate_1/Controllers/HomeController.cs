using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConfigurationTemplate_1.Models;
using ConfigurationTemplate_1.Services;

namespace ConfigurationTemplate_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ServiceABC _serviceABC;

        public HomeController(ILogger<HomeController> logger, ServiceABC serviceABC)
        {
            _logger = logger;
            _serviceABC = serviceABC;
        }

        public IActionResult Index()
        {
            return View(_serviceABC);
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
