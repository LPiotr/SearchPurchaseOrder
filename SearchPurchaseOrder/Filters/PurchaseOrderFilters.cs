using SearchPurchaseOrder.Models;
using SearchPurchaseOrder.Queries;

namespace SearchPurchaseOrder.Filters
{
    public class PurchaseOrderFilters : IOrderFilter
    {
        public IEnumerable<PurchaseOrder> Filter(IEnumerable<PurchaseOrder> orders, SearchPurchaseOrdersQuery query)
        {
            //extension method "."
            return orders
                .FilterByNumber(query.Number)
                .FilterByClientCode(query.ClientCodes)
                .FilterByDate(query.StartDate, query.EndDate);
        }
    }
}
