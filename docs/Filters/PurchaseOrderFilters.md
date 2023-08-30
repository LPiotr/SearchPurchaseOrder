# `PurchaseOrderFilters` Class Documentation
## Overview
The **`PurchaseOrderFilters`**  class provides a concrete implementation of the IOrderFilter interface, offering functionality to filter collections of PurchaseOrder objects based on various criteria defined in the SearchPurchaseOrdersQuery object.

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
Utilizes the PurchaseOrder model for filtering.

- **Queries:**
```csharp
SearchPurchaseOrder.Queries
```
Uses the SearchPurchaseOrdersQuery object to get filter criteria.

## Class Declaration
```csharp
public class PurchaseOrderFilters : IOrderFilter
```
**'PurchaseOrderFilters'** implements the **'IOrderFilter'** interface.


## Methods
**`Filter(IEnumerable<PurchaseOrder> orders, SearchPurchaseOrdersQuery query) -> IEnumerable<PurchaseOrder>`**
- **Description:** Provides functionality to filter a collection of **`PurchaseOrder`** objects based on the criteria defined in the given **`SearchPurchaseOrdersQuery`** object.

- **Parameters:**
    - **`orders`**: A collection of **`PurchaseOrder`** objects to be filtered.
    - **`query`**: A **`SearchPurchaseOrdersQuery`** object containing filter criteria.

- **Returns:**

    - **`IEnumerable<PurchaseOrder>`**: A collection of PurchaseOrder objects that match the filtering criteria.