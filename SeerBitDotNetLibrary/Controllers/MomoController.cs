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
    public class MomoController : ControllerBase
    {
        private readonly IMomo _IMomo;

        public MomoController(IMomo iMomo)
        {
            this._IMomo = iMomo;
        }

        [HttpPost]
        [Route("Transfer/{token}")]
        public async Task<IActionResult> Transfer([FromBody]MomoRequest request, string token)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._IMomo.Transfer(request, token);
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
