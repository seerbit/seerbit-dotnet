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
    public class OrderCheckOutService : IOrderCheckOut
    {
        private readonly Interchange _Interchange;
        private readonly IAuthentication _Authentication;
        private readonly Client _Client;


        public OrderCheckOutService(Interchange interchange, IAuthentication iAuthentication)
        {
            _Interchange = interchange;
            _Authentication = iAuthentication;
            _Client = iAuthentication.Environment();
        }

        public async Task<string> OrderBeforePayment(OrderCheckOutPaymentRequest request, string token)
        {
            try
            {
                var fullUrl = _Client.BaseUrl + "payments/order";

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

        public async Task<string> OrderAfterPayment(OrderCheckOutPaymentRequest1 request, string token)
        {
            try
            {
                var fullUrl = ClientConfig.EndpointTestBaseUrl + "products/orders";

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

        public async Task<string> UpdateOrder(OrderCheckOutPaymentRequest1 request, string token)
        {
            try
            {
                var fullUrl = ClientConfig.EndpointTestBaseUrl + "products/orders";

                var content = JsonConvert.SerializeObject(request);

                var httpResponse = await _Interchange.Put(fullUrl, token, content);


                var createdTask = await httpResponse.Content.ReadAsStringAsync();
                return createdTask;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> GetOrders(string token)
        {
            try
            {
                var fullUrl = ClientConfig.EndpointTestBaseUrl + "products/orders/publicKey/" + ClientConfig.TestPublicKey;

                var httpResponse = await _Interchange.Get(fullUrl, token);

                var createdTask = await httpResponse.Content.ReadAsStringAsync();
                return createdTask;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> GetOrderByPaymentReference(string paymentReference, string token)
        {
            try
            {
                var fullUrl = ClientConfig.EndpointTestBaseUrl + "products/orders/publicKey/" + ClientConfig.TestPublicKey + "/paymentReference/" + paymentReference;

                var httpResponse = await _Interchange.Get(fullUrl, token);

                var createdTask = await httpResponse.Content.ReadAsStringAsync();
                return createdTask;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> GetOrderByOrderId(string orderId, string token)
        {
            try
            {
                var fullUrl = ClientConfig.EndpointTestBaseUrl + "products/orders/publicKey/" + ClientConfig.TestPublicKey + "/orderId/" + orderId;

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
