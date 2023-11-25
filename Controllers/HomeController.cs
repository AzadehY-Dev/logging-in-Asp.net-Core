using Logging.Models;
using Logging.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly ILogger _logger;

        public HomeController(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger("Home");
        }
        public IActionResult Index()
        {
           // _logger.Log(LogLevel.Information, "Request Start");
           _logger.LogInformation("Rquest start...!");
            if(1==1)
            {
                _logger.LogWarning("file not found...");
            }
            try
            {
                throw new Exception();
            }
            catch (Exception ex) 
            {
                _logger.LogError(LogEvent.SomeErrorOccured,ex, "Error...!");
            }
            _logger.LogError(LogEvent.SpecialErrorOccured, "Test event id...!");

            int a=10, b=10;
            int c = a + b;
            _logger.LogDebug("the sum of two number");
            //trace use for show the amounts
            _logger.LogTrace($"c = {c}");
            try
            {
                throw new Exception();
            }
            catch (Exception ex) 
            {
                _logger.LogCritical(ex, "can not connect database");
            }
          
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
