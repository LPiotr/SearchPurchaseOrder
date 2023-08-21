using SearchPurchaseOrder.Models;
using SearchPurchaseOrder.Queries;

namespace SearchPurchaseOrder.Filters
{
    public class DateRangeFilter : IOrderFilter
    {
        public IEnumerable<PurchaseOrder> Filter(IEnumerable<PurchaseOrder> orders, SearchPurchaseOrdersQuery query)
        {
            if (query.StartDate.HasValue)
            {
                orders = orders.Where(o => o.OrderDate >= query.StartDate.Value);
            }
            if (query.EndDate.HasValue)
            {
                orders = orders.Where(o => o.OrderDate <= query.EndDate.Value);
            }

            return orders;
        }
    }
}
