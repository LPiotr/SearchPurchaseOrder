using MediatR;
using Microsoft.AspNetCore.Mvc;
using SearchPurchaseOrder.Queries;

namespace SearchPurchaseOrder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PurchaseOrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] SearchPurchaseOrdersQuery parameters)
        {

            var query = new SearchPurchaseOrdersQuery
            {
                Number = parameters.Number,
                StartDate = parameters.StartDate,
                EndDate = parameters.EndDate,
                ClientCodes = parameters.ClientCodes
            };

            var orders = await _mediator.Send(query);

            return Ok(orders);
        }
    }
}
