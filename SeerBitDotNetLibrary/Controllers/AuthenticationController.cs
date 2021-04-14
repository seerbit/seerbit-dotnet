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
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _IAuthentication;

        public AuthenticationController(IAuthentication iAuthentication)
        {
            this._IAuthentication = iAuthentication;
        }

        [HttpGet]
        [Route("{privateKey}/{publicKey}")]
        public async Task<IActionResult> Get(string privateKey, string publicKey)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._IAuthentication.GetKey(privateKey, publicKey);
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
        [Route("token/{privateKey}/{publicKey}")]
        public async Task<IActionResult> GetToken(string privateKey, string publicKey)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._IAuthentication.Token(privateKey, publicKey);
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
