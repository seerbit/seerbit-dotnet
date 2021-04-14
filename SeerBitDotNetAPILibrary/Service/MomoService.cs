using Newtonsoft.Json;
using SeerBitDotNetAPILibrary.Constant;
using SeerBitDotNetAPILibrary.Exchange;
using SeerBitDotNetAPILibrary.Interface;
using SeerBitDotNetAPILibrary.Model.Request;
using System;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Service
{
    public class MomoService : IMomo
    {
        private readonly Interchange _Interchange;
        private readonly IAuthentication _Authentication;
        private readonly Client _Client;


        public MomoService(Interchange interchange, 
                            IAuthentication iAuthentication)
        {
            _Interchange = interchange;
            _Authentication = iAuthentication;
            _Client = iAuthentication.Environment();
        }

        public async Task<string> Transfer(MomoRequest request, string token)
        {
            try
            {
                var fullUrl = _Client.BaseUrl + "payments/momo/otp";

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
