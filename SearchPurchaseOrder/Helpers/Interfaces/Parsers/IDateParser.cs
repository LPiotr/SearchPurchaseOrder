namespace SearchPurchaseOrder.Helpers.Interfaces.Parsers
{
    public interface IDateParser
    {
        DateTime? ParseDateToDesiredFormat(string? date, string format);
    }
}
