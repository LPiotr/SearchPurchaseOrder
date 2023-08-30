# `CsvOrderFileReader` Class Documentation

## Overview
The `CsvOrderFileReader` class implements the `IPurchaseOrderFileReader` interface to read purchase orders from a CSV file.

## Properties and Fields

- **_instance** (`CsvOrderFileReader`): A private static read-only instance of `CsvOrderFileReader`, adhering to the Singleton pattern.
  
- **_semaphore** (`SemaphoreSlim`): A private instance of `SemaphoreSlim` used to ensure thread-safe access to the `_orders` list.

- **_orders** (`List<PurchaseOrder>?`): A private nullable list that caches the purchase orders after the first read from the CSV file.

- **Instance** (`CsvOrderFileReader`): A public static property that returns the single instance of the class.

## Constructor

- **CsvOrderFileReader()**: A private constructor ensuring that the class adheres to the Singleton pattern.

## Methods

### `ReadOrders`

```csharp
public async Task<IEnumerable<PurchaseOrder>> ReadOrders(string path)
```

This method is responsible for reading and parsing the purchase orders from a given CSV file path. The reading is done using CsvHelper. The function uses a semaphore for thread safety, ensuring only one thread reads and initializes the _orders list. If _orders has already been initialized, it returns the cached list; otherwise, it reads from the file and caches the list for subsequent calls.


The method performs the following steps:

1. Checks if the _orders list is already initialized. If it is, it returns the list immediately.
1. Waits for access to the _semaphore to ensure thread safety.
1. Reads the CSV file using CsvHelper, making use of the provided PurchaseOrderMap for mapping.
1. Parses the records into the _orders list.
1. Releases the semaphore lock and returns the parsed list of orders.
