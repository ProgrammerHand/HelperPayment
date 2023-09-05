using HelperPayment.Application.Abstraction.Commands;
using HelperPayment.Application.Abstraction.Queries;
using HelperPayment.Application.Invoice.Commands;
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

            [HttpPost("")]
            public async Task<ActionResult> IssueInvoice(CreateInvoice command)
            {
                await _commandDispatcher.SendAsync(command);
                return Ok();
            }
        }
}
