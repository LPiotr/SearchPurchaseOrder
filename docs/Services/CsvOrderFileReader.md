# `CsvOrderFileReader` Documentation

`CsvOrderFileReader` is a Singleton class that provides functionality to read purchase orders from a CSV file and ensures thread safety while accessing the data.

## Class Structure

### Fields

- **_instance**: A private static read-only instance of the `CsvOrderFileReader`, ensuring the Singleton pattern.
  
- **_mutex**: A Mutex object to ensure thread safety when reading orders from a CSV file.

- **_orders**: A list to cache the purchase orders once they are read from the CSV.

### Properties

- **Instance**: Public property providing access to the Singleton instance of `CsvOrderFileReader`.

### Constructor

- **CsvOrderFileReader**: A private constructor ensuring that no instances can be created externally.

### Methods

- **ReadOrders**: Reads and caches purchase orders from the specified CSV file path.

## Method Descriptions

### `ReadOrders(string path)`

#### Parameters:

- **path** (type: `string`): The file path to the CSV containing the purchase orders.

#### Returns:

- A list of `PurchaseOrder` objects.

#### Description:

- If the orders are already cached, it returns the cached list.

- If the orders are not cached, it uses a mutex to ensure thread safety when accessing the CSV file. 

- The method reads the CSV, caches the purchase orders, and then returns the orders.

#### Usage:

To read purchase orders from a specified path:

```csharp
var orders = CsvOrderFileReader.Instance.ReadOrders("path/to/csv/file.csv");
