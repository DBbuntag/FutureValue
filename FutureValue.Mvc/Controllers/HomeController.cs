using FutureValue.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
            try
            {
                IEnumerable<FutureValuesModel> futureValuesModels;
                using (HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/FutureValues").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        futureValuesModels = response.Content.ReadAsAsync<IEnumerable<FutureValuesModel>>().Result;
                        foreach(var futureValues in futureValuesModels)
                        {
                            futureValues.ExecutionDetails = GetExecutionDetails(futureValues.FutureValuesId);
                        }
                        return View(futureValuesModels);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
                 
        }

        [HttpGet]
        public IActionResult ComputeFutureValue()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ComputeFutureValue(FutureValuesModel futureValuesModel)
        {
            try
            {
                using (HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/FutureValues", futureValuesModel).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = response.Content.ReadAsStringAsync().Result;
                        var res = JsonConvert.DeserializeObject<FutureValuesModel>(jsonString);
                        ViewData["ExecutionDetailsList"] = GetExecutionDetails(res.FutureValuesId);

                        return View();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet]
        public List<ExecutionDetailsModel> GetExecutionDetails(int id)
        {
            try
            {
                using (HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/ExecutionDetails/" + id).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsAsync<List<ExecutionDetailsModel>>().Result;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch(Exception e)
            {
                throw;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
