using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Model
{
    public class SeerBitSettingsModel
    {
        public string TestBaseUrl { get; set; }
        public string LiveBaseUrl { get; set; }
        public string PilotBaseUrl { get; set; }
        public string Environment { get; set; }
    }
}
