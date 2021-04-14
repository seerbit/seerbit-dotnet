using SeerBitDotNetAPILibrary.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Interface
{
    public interface ICard
    {
        Task<string> GetStatus(string paymentReference, string token);
    }
}
