using SeerBitDotNetAPILibrary.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Interface
{
    public interface IMomo
    {
        Task<string> Transfer(MomoRequest request, string token);
    }
}
