using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SeerBitDotNetAPILibrary.Exchange;
using SeerBitDotNetAPILibrary.Interface;
using SeerBitDotNetAPILibrary.Model;
using SeerBitDotNetAPILibrary.Model.Request;
using System;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Service
{
    public class StandardCheckOutService : IStandardCheckOut// AuthenticationRepos,
    {  
        private readonly Interchange _Interchange;
        private readonly IAuthentication _IAuthentication;
        private readonly Client _Client;


        public StandardCheckOutService(Interchange interchange, IAuthentication iAuthentication)
           // : base(null, interchange)
        {
            _Interchange = interchange;
            _IAuthentication = iAuthentication;
            _Client = iAuthentication.Environment();
        }

        public async Task<string> GenerateHash(StandardCheckOutHashRequest request, string token)
        {
            var fullUrl = _Client.BaseUrl + "encrypt/hashs";

            var content = JsonConvert.SerializeObject(request);

            var httpResponse = await _Interchange.Post(fullUrl, null, content);
            
            var createdTask = await httpResponse.Content.ReadAsStringAsync();

            return createdTask;
        }

        public async Task<string> Payment(StandardCheckPaymentRequest request, string token)
        {
            var hashRequest = new StandardCheckOutHashRequest() {
                amount = request.amount,
                callbackUrl = request.callbackUrl,
                country = request.country,
                currency = request.currency,
                email = request.email,
                paymentReference = request.paymentReference,
                productDescription = request.productDescription,
                productId = request.productId,
                publicKey = request.publicKey
            };

            var hashReponse = await this.GenerateHash(hashRequest, token);

            var parsed = JObject.Parse(hashReponse.ToString());
            
            request.hash = parsed.SelectToken("data.hash.hash").Value<string>();
            request.hashType = "sha256";

            var fullUrl = _Client.BaseUrl + "payments";

            var content = JsonConvert.SerializeObject(request);

            var httpResponse = await _Interchange.Post(fullUrl, token, content);

            var createdTask = await httpResponse.Content.ReadAsStringAsync();
            return createdTask;
        }
    }
}
