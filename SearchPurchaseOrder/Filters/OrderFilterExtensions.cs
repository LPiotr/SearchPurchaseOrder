using SearchPurchaseOrder.Models;
using System.Globalization;

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

        public static IEnumerable<PurchaseOrder> FilterByDate(this IEnumerable<PurchaseOrder> orders, string? startDate, string? endDate)
        {
            if (!string.IsNullOrEmpty(startDate))
            {
                DateTime parsedStartDate = DateTime.ParseExact(startDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                orders = orders.Where(o => o.OrderDate >= parsedStartDate);
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                DateTime parsedEndDate = DateTime.ParseExact(endDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                orders = orders.Where(o => o.OrderDate <= parsedEndDate);
            }
            return orders;
        }
    }
}
