using CsvHelper.Configuration;
using SearchPurchaseOrder.Models;

namespace SearchPurchaseOrder.Configuration
{
    public class PurchaseOrderMap : ClassMap<PurchaseOrder>
    {
        public PurchaseOrderMap()
        {
            Map(m => m.Number).Name("Number");
            Map(m => m.ClientCode).Name("ClientCode");
            Map(m => m.ClientName).Name("ClientName");
            Map(m => m.OrderDate).Name("OrderDate").TypeConverterOption.Format("dd.MM.yyyy");
            Map(m => m.ShipmentDate).Name("ShipmentDate").TypeConverterOption.Format("dd.MM.yyyy");
            Map(m => m.Quantity).Name("Quantity");
            Map(m => m.Confirmed).Name("Confirmed");
            Map(m => m.Value).Name("Value");
        }
    }
}
