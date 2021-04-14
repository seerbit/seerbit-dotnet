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
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethod _IPaymentMethod;

        public PaymentMethodController(IPaymentMethod iPaymentMethod)
        {
            this._IPaymentMethod = iPaymentMethod;
        }

        [HttpPost]
        [Route("OrderCheckOut/{token}")]
        public async Task<IActionResult> OrderBeforePayment([FromBody]InitiatePaymentRequest request, string token)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._IPaymentMethod.InitiatePayment(request, token);
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


        [HttpGet]
        [Route("Banks/{token}")]
        public async Task<IActionResult> Banks(string token)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._IPaymentMethod.GetBanks(token);
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
