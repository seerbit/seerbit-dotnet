using SeerBitDotNetAPILibrary.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeerBitDotNetAPILibrary.Interface
{
    public interface IAuthorise
    {
        Task<string> Authorise(AuthoriseRequest request, string token);
        Task<string> ThreeDSAuthorise(ThreeDSAuthoriseRequest request, string token);
    }
}
