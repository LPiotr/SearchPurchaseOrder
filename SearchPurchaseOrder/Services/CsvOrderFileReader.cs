using CsvHelper;
using CsvHelper.Configuration;
using SearchPurchaseOrder.Configuration;
using SearchPurchaseOrder.Models;
using System.Globalization;

namespace SearchPurchaseOrder.Interfaces
{
    /// <summary>
    /// Provides functionality to read purchase orders from a CSV file.
    /// This class implements the singleton pattern to ensure a single instance
    /// is used throughout the application. It uses CsvHelper for CSV parsing.
    /// </summary>
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

        /// <summary>
        /// Asynchronously reads purchase orders from a specified CSV file path.
        /// If the orders have already been read, it returns the cached orders.
        /// This method is thread-safe and uses a SemaphoreSlim to control access.
        /// </summary>
        /// <param name="path">The file path of the CSV to read.</param>
        /// <returns>A task that represents the asynchronous read operation. 
        /// The task result contains a collection of <see cref="PurchaseOrder"/>.</returns>
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

        /// <summary>
        /// Private helper method to asynchronously load purchase orders from a CSV file.
        /// This method is called internally by ReadOrders.
        /// </summary>
        /// <param name="path">The file path of the CSV to read.</param>
        /// <returns>A task that represents the asynchronous read operation. 
        /// The task result contains a list of <see cref="PurchaseOrder"/>.</returns>
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
