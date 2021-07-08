using FutureValue.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FutureValue.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            GlobalVariables.InitializeClient();
        }

        public IActionResult Index()
        {
            IEnumerable<FutureValuesModel> futureValuesModels;
            using (HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/FutureValues").Result)
            {
                if(response.IsSuccessStatusCode)
                {
                    futureValuesModels = response.Content.ReadAsAsync<IEnumerable<FutureValuesModel>>().Result;
                    return View(futureValuesModels);
                }
                else
                {
                    return BadRequest();
                }
            }
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
