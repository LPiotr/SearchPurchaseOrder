using SearchPurchaseOrder.Models;
using SearchPurchaseOrder.Queries;

namespace SearchPurchaseOrder.Filters
{
    public interface IOrderFilter
    {
        IEnumerable<PurchaseOrder> Filter(IEnumerable<PurchaseOrder> orders, SearchPurchaseOrdersQuery query);
    }
}