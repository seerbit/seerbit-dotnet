using SeerBitDotNetAPILibrary.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Interface
{
    public interface IRecurrent
    {
        Task<string> Initiate(InitiateRequest request, string token);
        Task<string> GetASubscription(string billingId, string token);
    }
}
