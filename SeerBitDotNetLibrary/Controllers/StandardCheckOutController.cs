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
    public class StandardCheckOutController : ControllerBase
    {

        private readonly IStandardCheckOut _IStandardCheckOut;

        public StandardCheckOutController(IStandardCheckOut iStandardCheckOut)
        {
            this._IStandardCheckOut = iStandardCheckOut;
        }

        [HttpPost]
        [Route("GenerateHash/{token}")]
        public async Task<IActionResult> GenerateHash([FromBody]StandardCheckOutHashRequest request, string token)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._IStandardCheckOut.GenerateHash(request, token);
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

        [HttpPost]
        [Route("Payment")]
        public async Task<IActionResult> Payment([FromBody]StandardCheckPaymentRequest request, string token)
        {
            try
            {
                //new StandardCheckPaymentRequest
                //{
                //    amount = "",
                //    callbackUrl = "",
                //    country = "",
                //    currency = "",
                //    email = "",
                //    hashType = "",
                //    paymentReference = "",
                //    productDescription = "",
                //    productId = "",
                //    publicKey = ""
                //};

                if (ModelState.IsValid)
                {
                    var result = await this._IStandardCheckOut.Payment(request, token);
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
