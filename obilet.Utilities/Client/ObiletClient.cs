using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace obilet.Utilities.Client
{
    public static class Client
    {
        static Client()
        {
            Initial();
        }

        public static void Initial()
        {
            Instance.BaseAddress = new Uri("https://v2-api.obilet.com");
            Instance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Instance.DefaultRequestHeaders.Add("Authorization", "Basic ZEdocGMybHpZV0p5WVc1a2JtVjNZbWx1");
        }
        public static HttpClient Instance { get; } = new HttpClient();
    }
}
