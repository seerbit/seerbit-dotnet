using SeerBitDotNetAPILibrary.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Interface
{
    public interface ITokenize
    {
        Task<string> Tokenize(Non3DSRequest request, string token);
    }
}
