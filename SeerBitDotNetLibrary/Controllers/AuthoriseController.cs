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
    public class AuthoriseController : ControllerBase
    {
        private readonly IAuthorise _IAuthorise;

        public AuthoriseController(IAuthorise _iNon3DS)
        {
            this._IAuthorise = _iNon3DS;
        }

        [HttpPost]
        [Route("Authorise/{token}")]
        public async Task<IActionResult> Authorise([FromBody]AuthoriseRequest request, string token)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._IAuthorise.Authorise(request, token);
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
        [Route("ThreeDSAuthorise/{token}")]
        public async Task<IActionResult> ThreeDSAuthorise([FromBody]ThreeDSAuthoriseRequest request, string token)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._IAuthorise.ThreeDSAuthorise(request, token);
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
