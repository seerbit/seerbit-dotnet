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
    public class AccountController : ControllerBase
    {
        private readonly IAccount _IAccount;

        public AccountController(IAccount _iAccount)
        {
            this._IAccount = _iAccount;
        }

        [HttpPost]
        [Route("Validate/{token}")]
        public async Task<IActionResult> ValidateTransaction([FromBody]ValidateRequest request, string token)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._IAccount.ValidateTransaction(request, token);
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
