using HelperPayment.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelperPayment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IInvoiceService _invoiceServ;

        public PaymentController(IInvoiceService invoiceServ)
        {
            _invoiceServ = invoiceServ;
        }

        [HttpPatch("pay/{invoiceId}")]
        public async Task<ActionResult> PayInvoice([FromRoute(Name = "invoiceId")] Guid invoiceId)
        {
            await _invoiceServ.HonourInvoiceAsync(invoiceId);
            return Ok();
        }

        [HttpGet("")]
        public async Task<ActionResult> GetInquiries()
        {

            return Ok(await _invoiceServ.GetAll());
        }

        [HttpGet("{invoiceId}")]
        public async Task<ActionResult> GetInquiry([FromRoute(Name = "invoiceId")] Guid invoiceId)
        {

            return Ok(await _invoiceServ.GetInvoiceById(invoiceId));
        }
    }
}
