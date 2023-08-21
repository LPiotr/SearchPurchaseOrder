using SearchPurchaseOrder.Models;
using SearchPurchaseOrder.Queries;

namespace SearchPurchaseOrder.Filters
{
    public class PurchaseOrderNumberFilter : IOrderFilter
    {
        public IEnumerable<PurchaseOrder> Filter(IEnumerable<PurchaseOrder> orders, SearchPurchaseOrdersQuery query)
        {
            return string.IsNullOrEmpty(query.Number) ? orders : orders.Where(o => o.Number == query.Number);
        }
    }
}
