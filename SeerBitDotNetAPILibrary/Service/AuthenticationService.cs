using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SeerBitDotNetAPILibrary.Constant;
using SeerBitDotNetAPILibrary.Exchange;
using SeerBitDotNetAPILibrary.Interface;
using SeerBitDotNetAPILibrary.Model;
using SeerBitDotNetAPILibrary.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Service
{
    public class AuthenticationService : IAuthentication
    {
        private readonly Interchange _Interchange;
        private IOptions<SeerBitSettingsModel> _settings;

        public AuthenticationService(IOptions<SeerBitSettingsModel> settings, Interchange interchange)
        {
            _settings = settings;
            _Interchange = interchange;
        }

        public async Task<string> GetKey(string privateKey, string publicKey)
        {
            var environment = this.Environment();

            var request = new AuthenticationRequest() { key = privateKey + "." + publicKey };

            var content = JsonConvert.SerializeObject(request);

            var httpResponse = await _Interchange.Post(environment.BaseUrl + "encrypt/keys", null, content);

            var createdTask = await httpResponse.Content.ReadAsStringAsync();
            return createdTask;
        }


        public async Task<string> Token(string privateKey, string publicKey)
        {
            var environment =  this.Environment();

            var request = new AuthenticationRequest()
            {
                key = privateKey + "." + publicKey
            };

            var content = JsonConvert.SerializeObject(request);

            var httpResponse = await _Interchange.Post(environment.BaseUrl + "encrypt/keys", null, content);

            var createdTask = await httpResponse.Content.ReadAsStringAsync();

            var parsed = JObject.Parse(createdTask);

            return parsed.SelectToken("data.EncryptedSecKey.encryptedKey").Value<string>();
        }

        public Client Environment()
        {
            Client client = new Client();

            string environment = _settings.Value.Environment;

            if (environment == "LIVE")
            {
                client.BaseUrl = _settings.Value.LiveBaseUrl;
            }
            else if (environment == "PILOT")
            {
                client.BaseUrl = _settings.Value.PilotBaseUrl;
            }
            else
            {
                client.BaseUrl = _settings.Value.TestBaseUrl;
            }

            return client;
        }

    }
}
