using SeerBitDotNetAPILibrary.Constant;
using SeerBitDotNetAPILibrary.Exchange;
using SeerBitDotNetAPILibrary.Interface;
using SeerBitDotNetAPILibrary.Model.Request;
using System;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Service
{
    public class CardService : ICard
    {
        private readonly Interchange _Interchange;
        private readonly IAuthentication _Authentication;
        private readonly Client _Client;


        public CardService(Interchange interchange, 
                         IAuthentication iAuthentication)
        { 
            _Interchange = interchange;
            _Authentication = iAuthentication;
            _Client = iAuthentication.Environment();
        }

        public async Task<string> GetStatus(string paymentReference, string token)
        {
            try
            {
                var fullUrl = _Client.BaseUrl + "payments/query/" + paymentReference;

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
