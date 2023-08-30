# `OrderFilterExtensions` Class Documentation
## Overview
The **`OrderFilterExtensions`** class provides a set of extension methods to filter PurchaseOrder objects based on various criteria.

## Namespace
```csharp
SearchPurchaseOrder.Filters
```
This class resides in the SearchPurchaseOrder.Filters namespace.

## Dependencies
- **Models:**
```csharp
SearchPurchaseOrder.Models
```
Utilizes the PurchaseOrder model to define the collection type for filtering.

- **System.Globalization:**

Used for parsing dates in a culture-specific manner.

## Methods
**`FilterByNumber(IEnumerable<PurchaseOrder> orders, string? orderNumber) -> IEnumerable<PurchaseOrder>`**

- **Description:** Filters a collection of PurchaseOrder objects based on the provided order number.

- **Parameters:**
    - **`orders`**: The collection of PurchaseOrder objects to be filtered.
    - **`orderNumber`**: The order number used for filtering.
- **Returns**:

**`IEnumerable<PurchaseOrder>`**: A collection of PurchaseOrder objects that match the filtering criteria.

**`FilterByClientCode(IEnumerable<PurchaseOrder> orders, List<string>? clientCodes) -> IEnumerable<PurchaseOrder>`**
 - **Description:** Filters a collection of PurchaseOrder objects based on the provided list of client codes.

- **Parameters:**
  - **`orders`**: The collection of PurchaseOrder objects to be filtered.
  - **`clientCodes`**: The list of client codes used for filtering.
Returns:

**`IEnumerable<PurchaseOrder>`**: A collection of PurchaseOrder objects that match the filtering criteria.

**`FilterByDate(IEnumerable<PurchaseOrder> orders, string? startDate, string? endDate) -> IEnumerable<PurchaseOrder>`**
 - **Description:** Filters a collection of PurchaseOrder objects based on the provided date range.

- **Parameters:**
    - orders: The collection of PurchaseOrder objects to be filtered.
    - startDate: The start date of the range.
    - endDate: The end date of the range.
- **Returns:**

**`IEnumerable<PurchaseOrder>`**: A collection of PurchaseOrder objects that fall within the specified date range.
