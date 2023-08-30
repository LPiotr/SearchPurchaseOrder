# `SearchPurchaseOrdersQuery` Class Documentation

## Overview

The `SearchPurchaseOrdersQuery` class represents a MediatR query, which serves as a DTO (Data Transfer Object) for searching purchase orders based on given criteria.

## Namespace

```csharp
namespace SearchPurchaseOrder.Queries
```

This class belongs to the SearchPurchaseOrder.Queries namespace.

## Dependencies

- **MediatR:** Utilized to create query objects that can be dispatched for handling by the associated MediatR handler.
- **SearchPurchaseOrder.Models:** Contains the models used within the `SearchPurchaseOrder` project.

## Properties

### `Number'
```csharp
public string? Number { get; set; }
```
An optional property that represents the purchase order number for the search.


### `StartDate'
```csharp
public string StartDate { get; set; } = string.Empty;
```
A mandatory property that specifies the start date of the search range. By default, it's initialized to an empty string.

### `EndDate'
```csharp
public string? EndDate { get; set; }
```

An optional property that specifies the end date of the search range.

### `ClientCodes'
```csharp
public List<string>? ClientCodes { get; set; }
```
An optional property containing a list of client codes to filter the search results by.