using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Model.Request
{
    public class Non3DSRequest
    {
        //public string privateKey { get; set; }
        public string publicKey { get; set; }
        public string amount { get; set; }
        public string fullName { get; set; }
        public string mobileNumber { get; set; }
        public string currency { get; set; }
        public string country { get; set; }
        public string paymentReference { get; set; }
        public string email { get; set; }
        public string productId { get; set; }
        public string productDescription { get; set; }
        public string cardNumber { get; set; }
        public string expiryMonth { get; set; }
        public string expiryYear { get; set; }
    }
}
