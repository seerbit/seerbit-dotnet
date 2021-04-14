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
    public class OrderCheckOutController : ControllerBase
    {
        private readonly IOrderCheckOut _IOrderCheckOut;

        public OrderCheckOutController(IOrderCheckOut iStandardCheckOut)
        {
            this._IOrderCheckOut = iStandardCheckOut;
        }

        [HttpPost]
        [Route("OrderBefore/{token}")]
        public async Task<IActionResult> OrderBeforePayment([FromBody]OrderCheckOutPaymentRequest request, string token)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._IOrderCheckOut.OrderBeforePayment(request, token);
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
        [Route("OrderAfter/{token}")]
        public async Task<IActionResult> OrderAfterPayment([FromBody] OrderCheckOutPaymentRequest1 request, string token)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._IOrderCheckOut.OrderAfterPayment(request, token);
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

        [HttpPut]
        [Route("Order/{token}")]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderCheckOutPaymentRequest1 request, string token)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._IOrderCheckOut.UpdateOrder(request, token);
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
        [Route("Order/{token}")]
        public async Task<IActionResult> Order(string token)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._IOrderCheckOut.GetOrders(token);
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
        [Route("Order/PaymentReference/{paymentReference}/{token}")]
        public async Task<IActionResult> OrderByPaymentReference(string paymentReference, string token)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._IOrderCheckOut.GetOrderByPaymentReference(paymentReference, token);
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
        [Route("Order/OrderId/{orderId}/{token}")]
        public async Task<IActionResult> GetOrderByOrderId(string orderId, string token)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._IOrderCheckOut.GetOrderByOrderId(orderId, token);
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
