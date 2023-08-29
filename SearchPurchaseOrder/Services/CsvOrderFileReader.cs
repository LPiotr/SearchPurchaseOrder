using CsvHelper;
using CsvHelper.Configuration;
using SearchPurchaseOrder.Configuration;
using SearchPurchaseOrder.Models;
using System.Globalization;

namespace SearchPurchaseOrder.Interfaces
{
    public class CsvOrderFileReader : IPurchaseOrderFileReader
    {
        private readonly List<PurchaseOrder> _orders = new List<PurchaseOrder>();

        public async Task<IEnumerable<PurchaseOrder>> ReadOrders(string path)
        {
            if(_orders.Any()) { return _orders; } 
            
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Encoding = System.Text.Encoding.UTF8,
                Delimiter = ",",
            };

            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, config);
            csv.Context.RegisterClassMap<PurchaseOrderMap>();

            while (await csv.ReadAsync())
            {
                var order = csv.GetRecord<PurchaseOrder>();
                if (order != null)
                {
                    _orders.Add(order);
                }
            }

            return _orders;
        }
    }
}
