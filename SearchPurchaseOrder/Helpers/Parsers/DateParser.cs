using SearchPurchaseOrder.Helpers.Interfaces.Parsers;
using System.Globalization;

namespace SearchPurchaseOrder.Helpers.Parsers
{
    public class DateParser : IDateParser
    {
        public DateTime? ParseDateToDesiredFormat(string? dateString, string format)
        {
            if (string.IsNullOrWhiteSpace(dateString))
            {
                return null;
            }
            return TryParseDate(dateString, format);
        }

        private static DateTime? TryParseDate(string dateString, string format)
        {
            if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                return parsedDate;
            }
            return null;
        }
    }
}