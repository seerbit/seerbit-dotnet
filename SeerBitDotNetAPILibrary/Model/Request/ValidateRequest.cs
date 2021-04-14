using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Model.Request
{
    public class ValidateRequest
    {
        public string privateKey { get; set; }
        public string publicKey { get; set; }
        public string linkingReference { get; set; }
        public string otp { get; set; }
    }
}
