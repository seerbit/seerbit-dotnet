using SeerBitDotNetAPILibrary.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Interface
{
    public interface INon3DS
    {
        Task<string> ChargeCard(Non3DSRequest request, string token);
    }
}
