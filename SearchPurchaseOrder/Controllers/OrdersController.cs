using MediatR;
using Microsoft.AspNetCore.Mvc;
using SearchPurchaseOrder.Helpers.Interfaces.Parsers;
using SearchPurchaseOrder.Models;
using SearchPurchaseOrder.Queries;

namespace SearchPurchaseOrder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDateParser _dateParser;

        public PurchaseOrdersController(IMediator mediator, IDateParser dateParser)
        {
            _mediator = mediator;
            _dateParser = dateParser;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] SearchPurchaseOrdersQuery parameters)
        {
            var query = new SearchPurchaseOrdersQuery
            {
                Number = parameters.Number,
                StartDate = _dateParser.ParseDateToDesiredFormat(Convert.ToString(parameters.StartDate), "dd.MM.yyyy"),
                EndDate = _dateParser.ParseDateToDesiredFormat(Convert.ToString(parameters.EndDate), "dd.MM.yyyy"),
                ClientCodes = parameters.ClientCodes
            };

            var orders = await _mediator.Send(query);
            return Ok(orders);
        }
    }
}
