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
    public class PaymentMethodService : IPaymentMethod
    {
        private readonly Interchange _Interchange;
        private readonly IAuthentication _Authentication;
        private readonly Client _Client;


        public PaymentMethodService(Interchange interchange, IAuthentication iAuthentication)
        {
            _Interchange = interchange;
            _Authentication = iAuthentication;
            _Client = iAuthentication.Environment();
        }

        public async Task<string> InitiatePayment(InitiatePaymentRequest request, string token)
        {
            try
            {
                var fullUrl = _Client.BaseUrl + "payments/initiates";

                var content = JsonConvert.SerializeObject(request);

                //var key = await _Authentication.Token(request.privateKey, request.publicKey);

                var httpResponse = await _Interchange.Post(fullUrl, token, content);

                var createdTask = await httpResponse.Content.ReadAsStringAsync();
                return createdTask;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> GetBanks(string token)
        {
            try
            {
                var fullUrl = _Client.BaseUrl + "banks/merchant/" + ClientConfig.TestPublicKey;

                var httpResponse = await _Interchange.Get(fullUrl, token);

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
