using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Model.Request
{
    public class OrderCheckOutPaymentRequest1
    {
        //public string privateKey { get; set; }
        public string publicKey { get; set; }
        public string paymentReference { get; set; }
        public List<Orders> orders { get; set; }
    }

}
