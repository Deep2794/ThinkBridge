using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ShopBridgeMVC
{
    public static class GlobalVariables
    {
        public static HttpClient WebAPIClient = new HttpClient();

        static GlobalVariables()
        {
            WebAPIClient.BaseAddress = new Uri("https://localhost:44300/api/");
            WebAPIClient.DefaultRequestHeaders.Clear();
            WebAPIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}