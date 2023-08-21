using CsvHelper;
using CsvHelper.Configuration;
using SearchPurchaseOrder.Models;
using System.Globalization;

namespace SearchPurchaseOrder.Interfaces
{
    public class CsvOrderFileReader : IPurchaseOrderFileReader
    {
        public async Task<IEnumerable<PurchaseOrder>> ReadOrders(string path)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, config);

            var orders = new List<PurchaseOrder>();
            while (await csv.ReadAsync())
            {
                var order = csv.GetRecord<PurchaseOrder>();
                if (order != null)
                    orders.Add(order);
            }

            return orders;
        }
    }
}
