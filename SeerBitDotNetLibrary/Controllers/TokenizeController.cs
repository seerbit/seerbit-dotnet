using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeerBitDotNetAPILibrary.Interface;
using SeerBitDotNetAPILibrary.Model.Request;

namespace SeerBitDotNetLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenizeController : ControllerBase
    {
        private readonly ITokenize _ITokenize;

        public TokenizeController(ITokenize _iTokenize)
        {
            this._ITokenize = _iTokenize;
        }

        [HttpPost]
        [Route("Tokenize/{token}")]
        public async Task<IActionResult> Tokenize([FromBody]Non3DSRequest request, string token)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._ITokenize.Tokenize(request, token);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadGateway);
                response.ReasonPhrase = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
