using SeerBitDotNetAPILibrary.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Interface
{
    public interface IOrderCheckOut
    {
        Task<string> OrderBeforePayment(OrderCheckOutPaymentRequest request, string token);

        Task<string> OrderAfterPayment(OrderCheckOutPaymentRequest1 request, string token);
        Task<string> UpdateOrder(OrderCheckOutPaymentRequest1 request, string token);
        Task<string> GetOrders(string token);
        Task<string> GetOrderByPaymentReference(string paymentReference, string token);

        Task<string> GetOrderByOrderId(string orderId, string token);

    }
}
