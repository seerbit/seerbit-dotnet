using SeerBitDotNetAPILibrary.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Interface
{
    public interface IStandardCheckOut
    {
        Task<string> GenerateHash(StandardCheckOutHashRequest request, string token);

        Task<string> Payment(StandardCheckPaymentRequest request, string token);
    }
}
