using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HangFire_PoC.Models;
using Hangfire;

namespace HangFire_PoC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            RecurringJob.AddOrUpdate(() => Debug.WriteLine("Recurring"), Cron.Minutely());
            RecurringJob.AddOrUpdate(() => CallJobMethod(), Cron.Minutely());

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

        public void CallJobMethod()
        {
            Debug.WriteLine("Method Call");
        }
    }
}
