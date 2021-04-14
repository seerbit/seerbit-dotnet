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
    public class Non3DSController : ControllerBase
    {
        private readonly INon3DS _INon3DS;

        public Non3DSController(INon3DS _iNon3DS)
        {
            this._INon3DS = _iNon3DS;
        }

        [HttpPost]
        [Route("Transfer/{token}")]
        public async Task<IActionResult> Transfer([FromBody]Non3DSRequest request, string token)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._INon3DS.ChargeCard(request, token);
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
