using SearchPurchaseOrder.Models;

namespace SearchPurchaseOrder.Filters
{
    public static class OrderFilterExtensions
    {
        public static IEnumerable<PurchaseOrder> FilterByNumber(this IEnumerable<PurchaseOrder> orders, string? orderNumber)
        {
            return string.IsNullOrEmpty(orderNumber) ? orders : orders.Where(o => o.Number == orderNumber);
        }

        public static IEnumerable<PurchaseOrder> FilterByClientCode(this IEnumerable<PurchaseOrder> orders, List<string>? clientCodes)
        {
            return clientCodes?.Count > 0 ? orders.Where(o => clientCodes.Contains(o.ClientCode)) : orders;
        }

        public static IEnumerable<PurchaseOrder> FilterByDate(this IEnumerable<PurchaseOrder> orders, DateTime? startDate, DateTime? endDate)
        {
            if (startDate.HasValue)
            {
                orders = orders.Where(o => o.OrderDate >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                orders = orders.Where(o => o.OrderDate <= endDate.Value);
            }
            return orders;
        }
    }
}
