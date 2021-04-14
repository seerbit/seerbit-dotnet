using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Model.Request
{
    public class StandardCheckPaymentRequest
    {
        public string privateKey { get; set; }
        public string publicKey { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public string country { get; set; }
        public string paymentReference { get; set; }
        public string email { get; set; }
        public string productId { get; set; }
        public string productDescription { get; set; }
        public string callbackUrl { get; set; }

        [JsonIgnore]
        public string hash { get; set; }

        [JsonIgnore]
        public string hashType { get; set; }
    }
}
