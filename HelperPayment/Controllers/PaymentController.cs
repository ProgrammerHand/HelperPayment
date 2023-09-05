using HelperPayment.Application.Abstraction.Commands;
using HelperPayment.Application.Abstraction.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HelperPayment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
            private readonly ICommandDispatcher _commandDispatcher;
            private readonly IQueryDispatcher _queryDispatcher;

            public PaymentController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
            {
                _commandDispatcher = commandDispatcher;
                _queryDispatcher = queryDispatcher;
            }

            [HttpPost(""), Authorize]
            public async Task<ActionResult> issueInvoice(CreateInquiry command)
            {
                await _commandDispatcher.SendAsync();
            }
        }
}
