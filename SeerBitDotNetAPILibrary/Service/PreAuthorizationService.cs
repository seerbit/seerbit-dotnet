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
    public class PreAuthorizationService : IPreAuthorization
    {
        private readonly Interchange _Interchange;
        private readonly IAuthentication _Authentication;
        private readonly Client _Client;


        public PreAuthorizationService(Interchange interchange,
                            IAuthentication iAuthentication)
        {
            _Interchange = interchange;
            _Authentication = iAuthentication;
            _Client = iAuthentication.Environment();
        }

        public async Task<string> Capture(CaptureRequest request, string token)
        {
            try
            {
                var fullUrl = _Client.BaseUrl + "payments/capture";

                var content = JsonConvert.SerializeObject(request);

                var key = await _Authentication.Token(request.privateKey, request.publicKey);

                var httpResponse = await _Interchange.Post(fullUrl, key, content);


                var createdTask = await httpResponse.Content.ReadAsStringAsync();
                return createdTask;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> Refund(RefundRequest request, string token)
        {
            try
            {
                var fullUrl = _Client.BaseUrl + "payments/refund";

                var content = JsonConvert.SerializeObject(request);

                var key = await _Authentication.Token(request.privateKey, request.publicKey);

                var httpResponse = await _Interchange.Post(fullUrl, key, content);


                var createdTask = await httpResponse.Content.ReadAsStringAsync();
                return createdTask;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> Cancel(CancelRequest request, string token)
        {
            try
            {
                var fullUrl = _Client.BaseUrl + "payments/cancel";

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
