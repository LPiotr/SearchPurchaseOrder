# `IOrderFilter ` Interface Documentation

## Overview

The **`IOrderFilter`** interface defines a contract for filtering operations on a collection of PurchaseOrder objects based on provided query parameters.
## Namespace

```csharp
SearchPurchaseOrder.Filters
```
This interface resides in the SearchPurchaseOrder.Filters namespace.

## Dependencies

- ### Models
```csharp
SearchPurchaseOrder.Models
```
Utilizes the PurchaseOrder model to define the collection type for filtering.

- ### Queries
```csharp
SearchPurchaseOrder.Queries
```
Uses the SearchPurchaseOrdersQuery class to specify the criteria for filtering.

## Methods

`Filter(IEnumerable<PurchaseOrder> orders, SearchPurchaseOrdersQuery query) -> IEnumerable<PurchaseOrder>`
- **Description:** Filters a collection of PurchaseOrder objects based on the provided SearchPurchaseOrdersQuery criteria.

- **Parameters:**

   - **`orders`**: The collection of PurchaseOrder objects to be filtered.
   - **`query`**: The criteria used for filtering.
  
- **Returns:**
    - **`IEnumerable<PurchaseOrder>`**: A collection of PurchaseOrder objects that match the filtering criteria.