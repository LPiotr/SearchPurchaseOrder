using SearchPurchaseOrder.Models;
using System.Globalization;

namespace SearchPurchaseOrder.Filters
{
    /// <summary>
    /// Provides extension methods for filtering collections of PurchaseOrder objects.
    /// These methods enable filtering by order number, client code, or date range.
    /// </summary>
    public static class OrderFilterExtensions
    {
        /// <summary>
        /// Filters a collection of PurchaseOrder objects by a specific order number.
        /// </summary>
        /// <param name="orders">The collection of PurchaseOrder objects to filter.</param>
        /// <param name="orderNumber">The order number to filter by.</param>
        /// <returns>A filtered collection of PurchaseOrder objects.</returns>
        public static IEnumerable<PurchaseOrder> FilterByNumber(this IEnumerable<PurchaseOrder> orders, string? orderNumber)
        {
            return string.IsNullOrEmpty(orderNumber)
                   ? orders
                   : orders.Where(o => o.Number == orderNumber);
        }

        /// <summary>
        /// Filters a collection of PurchaseOrder objects by a list of client codes.
        /// </summary>
        /// <param name="orders">The collection of PurchaseOrder objects to filter.</param>
        /// <param name="clientCodes">The list of client codes to filter by.</param>
        /// <returns>A filtered collection of PurchaseOrder objects.</returns>
        public static IEnumerable<PurchaseOrder> FilterByClientCode(this IEnumerable<PurchaseOrder> orders, List<string>? clientCodes)
        {
            return (clientCodes == null || !clientCodes.Any())
                   ? orders
                   : orders.Where(o => clientCodes.Contains(o.ClientCode));
        }

        /// <summary>
        /// Filters a collection of PurchaseOrder objects by a date range.
        /// </summary>
        /// <param name="orders">The collection of PurchaseOrder objects to filter.</param>
        /// <param name="startDate">The start date of the range in "dd.MM.yyyy" format.</param>
        /// <param name="endDate">The end date of the range in "dd.MM.yyyy" format.</param>
        /// <returns>A filtered collection of PurchaseOrder objects.</returns>
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
