using MediatR;
using Microsoft.Extensions.Options;
using SearchPurchaseOrder.Configuration;
using SearchPurchaseOrder.Filters;
using SearchPurchaseOrder.Interfaces;
using SearchPurchaseOrder.Models;

namespace SearchPurchaseOrder.Queries
{
    /// <summary>
    /// Handles the processing of a SearchPurchaseOrdersQuery.
    /// It utilizes an IPurchaseOrderFileReader to read orders and an IOrderFilter
    /// to apply filtering based on the query parameters.
    /// </summary>
    public class SearchOrdersQueryHandler : IRequestHandler<SearchPurchaseOrdersQuery, IEnumerable<PurchaseOrder>>
    {
        private readonly IPurchaseOrderFileReader _reader;
        private readonly IOrderFilter _filter;
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the SearchOrdersQueryHandler class.
        /// </summary>
        /// <param name="reader">The reader for accessing purchase order data.</param>
        /// <param name="filter">The filter to apply on the purchase orders.</param>
        /// <param name="settings">The application settings which contain the file path for the data.</param>
        public SearchOrdersQueryHandler(IPurchaseOrderFileReader reader, IOrderFilter filter, IOptions<PurchaseOrderDataSettings> settings)
        {
            _reader = reader;
            _filter = filter;
            _filePath = settings.Value.FilePath;
        }

        /// <summary>
        /// Handles the execution of the SearchPurchaseOrdersQuery. Reads orders from a file,
        /// applies filters based on the query, and returns the filtered orders.
        /// </summary>
        /// <param name="request">The search query with filter criteria.</param>
        /// <param name="cancellationToken">A token for cancelling the operation if required.</param>
        /// <returns>A task that represents the asynchronous operation. 
        /// The task result contains a collection of filtered <see cref="PurchaseOrder"/>.</returns>
        public async Task<IEnumerable<PurchaseOrder>> Handle(SearchPurchaseOrdersQuery request, CancellationToken cancellationToken)
        {
            var allOrders = await _reader.ReadOrders(_filePath);

            allOrders = _filter.Filter(allOrders, request);

            return allOrders.ToList();
        }
    }
}
