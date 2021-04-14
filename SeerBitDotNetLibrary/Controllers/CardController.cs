using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeerBitDotNetAPILibrary.Interface;

namespace SeerBitDotNetLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICard _ICard;

        public CardController(ICard _iCard)
        {
            this._ICard = _iCard;
        }

        [HttpGet]
        [Route("Status/PaymentReference/{paymentReference}/{token}")]
        public async Task<IActionResult> GetStatus(string paymentReference, string token)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._ICard.GetStatus(paymentReference, token);
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
