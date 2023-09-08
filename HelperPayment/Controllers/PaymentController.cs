using HelperPayment.Core.Services;
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
    }
}
