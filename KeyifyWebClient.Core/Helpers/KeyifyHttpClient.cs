using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace KeyifyWebClient.Core.Helpers
{
    public static class KeyifyHttpClient
    {
        public static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            //TODO: Shouldn't be hardcoded, move into a config
            client.BaseAddress = new Uri(@"http://localhost:89/");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}