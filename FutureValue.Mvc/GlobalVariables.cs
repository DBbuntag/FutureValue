using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FutureValue.Mvc
{
    public class GlobalVariables
    {
        public static HttpClient WebApiClient { get; set; }

        public static void InitializeClient()
        {
            WebApiClient = new HttpClient();
            WebApiClient.BaseAddress = new Uri("https://localhost:44377");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
