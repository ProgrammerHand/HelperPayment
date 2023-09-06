using HelperPayment.Core.Abstraction.Commands;
using HelperPayment.Core.Abstraction.Queries;
using HelperPayment.Core.Services.Invoice.Commands;
using HelperPayment.Core.Services.Offer.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HelperPayment.Api.Controllers
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

        [HttpGet("")]
        public async Task<ActionResult> GetOffers()
        {
            return Ok(await _queryDispatcher.QueryAsync(new GetOffers()));
        }
    }
}
