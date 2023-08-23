using SearchPurchaseOrder.Models;
using System.Globalization;

namespace SearchPurchaseOrder.Filters
{
    public static class OrderFilterExtensions
    {
        public static IEnumerable<PurchaseOrder> FilterByNumber(this IEnumerable<PurchaseOrder> orders, string? orderNumber)
        {
            return string.IsNullOrEmpty(orderNumber)
                   ? orders
                   : orders.Where(o => o.Number == orderNumber);
        }

        public static IEnumerable<PurchaseOrder> FilterByClientCode(this IEnumerable<PurchaseOrder> orders, List<string>? clientCodes)
        {
            return (clientCodes == null || !clientCodes.Any())
                   ? orders
                   : orders.Where(o => clientCodes.Contains(o.ClientCode));
        }

        public static IEnumerable<PurchaseOrder> FilterByDate(this IEnumerable<PurchaseOrder> orders, string? startDate, string? endDate)
        {
            var culture = CultureInfo.InvariantCulture;
            bool isStartDateValid = DateTime.TryParseExact(startDate, "dd.MM.yyyy", culture, DateTimeStyles.None, out DateTime startDateTime);
            bool isEndDateValid = DateTime.TryParseExact(endDate, "dd.MM.yyyy", culture, DateTimeStyles.None, out DateTime endDateTime);

            return orders.Where(o => (!isStartDateValid || o.OrderDate >= startDateTime) &&
                                     (!isEndDateValid || o.OrderDate <= endDateTime));
        }
    }
}
