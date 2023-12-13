using CsvHelper;
using CsvHelper.Configuration;
using SearchPurchaseOrder.Configuration;
using SearchPurchaseOrder.Models;
using System.Globalization;

namespace SearchPurchaseOrder.Interfaces
{
    public sealed class CsvOrderFileReader : IPurchaseOrderFileReader
    {
        private static readonly CsvOrderFileReader _instance = new();
        private static readonly CsvConfiguration _csvConfig = new(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Encoding = System.Text.Encoding.UTF8,
            Delimiter = ","
        };
        private readonly SemaphoreSlim _semaphore = new(1);
        private List<PurchaseOrder>? _orders = null;

        public static CsvOrderFileReader Instance => _instance;

        private CsvOrderFileReader() { }

        public async Task<IEnumerable<PurchaseOrder>> ReadOrders(string path)
        {
            if (_orders != null)
            {
                return _orders;
            }

            if (!_semaphore.Wait(0)) // Non-blocking check
            {
                await _semaphore.WaitAsync();
            }

            try
            {
                if (_orders != null) return _orders;
                _orders = await LoadOrdersFromCsvAsync(path);
                return _orders;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private static async Task<List<PurchaseOrder>> LoadOrdersFromCsvAsync(string path)
        {
            var orders = new List<PurchaseOrder>();

            try
            {
                using var reader = new StreamReader(path);
                using var csv = new CsvReader(reader, _csvConfig);
                csv.Context.RegisterClassMap<PurchaseOrderMap>();

                await foreach (var order in csv.GetRecordsAsync<PurchaseOrder>())
                {
                    orders.Add(order);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex}");
                throw;
            }

            return orders;
        }
    }
}
