using SeerBitDotNetAPILibrary.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Interface
{
    public interface IPreAuthorization
    {
        Task<string> Capture(CaptureRequest request, string token);
        Task<string> Refund(RefundRequest request, string token);
        Task<string> Cancel(CancelRequest request, string token);
    }
}
