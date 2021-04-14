using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Exchange
{
    public class Interchange
    {
        private readonly HttpClient _client;

        public Interchange(HttpClient client)
        {
            _client = client;
        }

        //HttpClient _client = new HttpClient();

        public async Task<HttpResponseMessage> Post(string url, string key, string json)
        {

            if (!string.IsNullOrEmpty(key))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);
            }

            return await _client.PostAsync(url, new StringContent(json, Encoding.Default, "application/json"));
        }

        public async Task<HttpResponseMessage> Validate(string url, string key, string json)
        {

            if (!string.IsNullOrEmpty(key))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);
            }

            return await _client.PostAsync(url, new StringContent(json, Encoding.Default, "application/json"));
        }

        public async Task<HttpResponseMessage> Put(string url, string key, string json)
        {

            if (!string.IsNullOrEmpty(key))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);
            }

            return await _client.PutAsync(url, new StringContent(json, Encoding.Default, "application/json"));
        }

        public async Task<HttpResponseMessage> Get(string url, string key)
        {

            if (!string.IsNullOrEmpty(key))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);
            }

            return await _client.GetAsync(url);
        }
    }
}
