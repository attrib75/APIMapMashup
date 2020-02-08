using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using MapMashup.Models;

namespace MapMashup.DAL
{
    public class BingAPIClient
    {
        private static string host;
        private static string key;
        private static string market = "en-US";
        private static string path = "/localbusinesses/search";
        private static string query = "chicago restaurant";

        public BingAPIClient(string _webHost, string _apiKey)
        {
            host = _webHost;
            key = _apiKey;
        }

        public async Task<IList<Value>> GetBusinesses(string searchTerm)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
            //client.DefaultRequestHeaders.Add("X-Search-Location", "41.8781, -87.6298");
            string uri = host + path + "?mkt=" + market + "&q=" + System.Net.WebUtility.UrlEncode(query + " " + Uri.EscapeDataString(searchTerm));

            HttpResponseMessage response = await client.GetAsync(uri);

            string contentString = await response.Content.ReadAsStringAsync();
            SearchResponse SearchResponse = JsonConvert.DeserializeObject<SearchResponse>(contentString);
            return SearchResponse.Places.Value;
        }
    }
}