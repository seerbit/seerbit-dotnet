using SeerBitDotNetAPILibrary.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Interface
{
    public interface IPaymentMethod
    {
        Task<string> InitiatePayment(InitiatePaymentRequest request, string token);
        Task<string> GetBanks(string token);
    }
}
