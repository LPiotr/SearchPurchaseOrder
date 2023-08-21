using SearchPurchaseOrder.Models;
using SearchPurchaseOrder.Queries;

namespace SearchPurchaseOrder.Filters
{
    public class ClientCodeFilter : IOrderFilter
    {
        public IEnumerable<PurchaseOrder> Filter(IEnumerable<PurchaseOrder> orders, SearchPurchaseOrdersQuery query)
        {
            return query.ClientCodes?.Count > 0 ? orders.Where(o => query.ClientCodes.Contains(o.ClientCode)) : orders;
        }
    }
}
