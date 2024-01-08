using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentManagementApp.BusinessLayer.Interfaces;
using PaymentManagementApp.BusinessLayer.ViewModels;
using PaymentManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentManagementApp.Controllers
{
    [ApiController]
    public class PaymentManagementController : ControllerBase
    {
        private readonly IPaymentManagementService  _paymentService;
        public PaymentManagementController(IPaymentManagementService paymentservice)
        {
             _paymentService = paymentservice;
        }

        [HttpPost]
        [Route("create-payment")]
        [AllowAnonymous]
        public async Task<IActionResult> CreatePayment([FromBody] Payment model)
        {
            var PaymentExists = await  _paymentService.GetPaymentById(model.PaymentId);
            if (PaymentExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Payment already exists!" });
            var result = await  _paymentService.CreatePayment(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Payment creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Payment created successfully!" });

        }


        [HttpPut]
        [Route("update-payment")]
        public async Task<IActionResult> UpdatePayment([FromBody] PaymentViewModel model)
        {
            var Payment = await  _paymentService.UpdatePayment(model);
            if (Payment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Payment With Id = {model.PaymentId} cannot be found" });
            }
            else
            {
                var result = await  _paymentService.UpdatePayment(model);
                return Ok(new Response { Status = "Success", Message = "Payment updated successfully!" });
            }
        }

      
        [HttpDelete]
        [Route("delete-payment")]
        public async Task<IActionResult> DeletePayment(long id)
        {
            var Payment = await  _paymentService.GetPaymentById(id);
            if (Payment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Payment With Id = {id} cannot be found" });
            }
            else
            {
                var result = await  _paymentService.DeletePaymentById(id);
                return Ok(new Response { Status = "Success", Message = "Payment deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("get-payment-by-id")]
        public async Task<IActionResult> GetPaymentById(long id)
        {
            var Payment = await  _paymentService.GetPaymentById(id);
            if (Payment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Payment With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(Payment);
            }
        }

        [HttpGet]
        [Route("get-all-payments")]
        public async Task<IEnumerable<Payment>> GetAllPayments()
        {
            return   _paymentService.GetAllPayments();
        }
    }
}
