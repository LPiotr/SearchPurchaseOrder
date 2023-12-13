using MediatR;
using Microsoft.AspNetCore.Mvc;
using SearchPurchaseOrder.Queries;

namespace SearchPurchaseOrder.Controllers
{
    /// <summary>
    /// The PurchaseOrdersController is responsible for handling HTTP requests
    /// related to purchase orders. It uses MediatR to send queries for processing.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the PurchaseOrdersController class.
        /// </summary>
        /// <param name="mediator">MediatR's mediator for sending queries.</param>
        public PurchaseOrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Handles HTTP GET requests to retrieve purchase orders based on provided search parameters.
        /// This method creates a SearchPurchaseOrdersQuery and sends it via MediatR to obtain filtered results.
        /// </summary>
        /// <param name="parameters">Search parameters for filtering purchase orders.</param>
        /// <returns>An IActionResult containing the list of filtered purchase orders or an error response.</returns>
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
