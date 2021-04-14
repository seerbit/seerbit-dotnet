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
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Service
{
    public class AuthoriseService : IAuthorise
    {
        private readonly Interchange _Interchange;
        private readonly IAuthentication _Authentication;
        private readonly Client _Client;


        public AuthoriseService(Interchange interchange, 
                            IAuthentication iAuthentication)
        {
            _Interchange = interchange;
            _Authentication = iAuthentication;
            _Client = iAuthentication.Environment();
        }

        public async Task<string> Authorise(AuthoriseRequest request, string token)
        {
            try
            {
                var fullUrl = _Client.BaseUrl + "payments/authorise";

                var content = JsonConvert.SerializeObject(request);

                var httpResponse = await _Interchange.Post(fullUrl, token, content);


                var createdTask = await httpResponse.Content.ReadAsStringAsync();
                return createdTask;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> ThreeDSAuthorise(ThreeDSAuthoriseRequest request, string token)
        {
            try
            {
                var fullUrl = _Client.BaseUrl + "payments/authorise3ds";

                var content = JsonConvert.SerializeObject(request);

                var httpResponse = await _Interchange.Post(fullUrl, token, content);


                var createdTask = await httpResponse.Content.ReadAsStringAsync();
                return createdTask;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
