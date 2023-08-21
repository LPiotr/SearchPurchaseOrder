using MediatR;
using Microsoft.Extensions.Options;
using SearchPurchaseOrder.Configuration;
using SearchPurchaseOrder.Filters;
using SearchPurchaseOrder.Interfaces;
using SearchPurchaseOrder.Models;

namespace SearchPurchaseOrder.Queries
{
    public class SearchOrdersQueryHandler : IRequestHandler<SearchPurchaseOrdersQuery, IEnumerable<PurchaseOrder>>
    {
        private readonly IPurchaseOrderFileReader _reader;
        private readonly IOrderFilter _filter;
        private readonly string _filePath;

        public SearchOrdersQueryHandler(IPurchaseOrderFileReader reader, IOrderFilter filter, IOptions<PurchaseOrderDataSettings> settings)
        {
            _reader = reader;
            _filter = filter;
            _filePath = settings.Value.FilePath;
        }

        public async Task<IEnumerable<PurchaseOrder>> Handle(SearchPurchaseOrdersQuery request, CancellationToken cancellationToken)
        {
            var allOrders = await _reader.ReadOrders(_filePath);
           
            allOrders = _filter.Filter(allOrders, request); 
         
            return allOrders.ToList();
        }
    }
}
