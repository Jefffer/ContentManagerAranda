using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace WebMvc
{
    public static class _Global
    {
        public static HttpClient apiClient = new HttpClient();

        static _Global()
        {
            apiClient.BaseAddress = new Uri("http://localhost:57412/api/");
            apiClient.DefaultRequestHeaders.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}