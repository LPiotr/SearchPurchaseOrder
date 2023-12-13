﻿using CsvHelper.Configuration;
using CsvHelper;
using SearchPurchaseOrder.Configuration;
using SearchPurchaseOrder.Models;
using System.Globalization;

namespace SearchPurchaseOrder.Interfaces
{
    public sealed class CsvOrderFileReader : IPurchaseOrderFileReader
    {
        private static readonly CsvOrderFileReader _instance = new();
        private readonly SemaphoreSlim _semaphore = new(1); 
        private List<PurchaseOrder>? _orders = null;

        public static CsvOrderFileReader Instance => _instance;

        public async Task<IEnumerable<PurchaseOrder>> ReadOrders(string path)
        {
            if (_orders != null) { return _orders; }

            await _semaphore.WaitAsync();
            try
            {
                if (_orders != null) { return _orders; }

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    Encoding = System.Text.Encoding.UTF8,
                    Delimiter = ",",
                };

                using var reader = new StreamReader(path);
                using var csv = new CsvReader(reader, config);
                csv.Context.RegisterClassMap<PurchaseOrderMap>();

                var orders = new List<PurchaseOrder>();

                while (await csv.ReadAsync())
                {
                    var order = csv.GetRecord<PurchaseOrder>();
                    if (order != null)
                    {
                        orders.Add(order);
                    }
                }

                _orders = orders;
                return _orders;
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
