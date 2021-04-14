using SeerBitDotNetAPILibrary.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Interface
{
    public interface IAuthentication
    {
        Task<string> GetKey(string privateKey, string publicKey);
        Task<string> Token(string privateKey, string publicKey);
        Client Environment();
    }
}
