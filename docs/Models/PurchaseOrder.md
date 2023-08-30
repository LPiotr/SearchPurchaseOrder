# `PurchaseOrder` Class Documentation

## Overview

The `PurchaseOrder` class represents a model for purchase orders. It contains essential details about a purchase order, such as order numbers, client information, dates, quantity, and other related attributes.

## Namespace

```csharp
namespace SearchPurchaseOrder.Models
```
This class is part of the SearchPurchaseOrder.Models namespace.

## Dependencies
- **CsvHelper.Configuration.Attributes:** Utilized for CSV-related configurations and annotations.
- **System.ComponentModel.DataAnnotations:** Provides attributes that can be used for data validation.

## Class  Properties
### `Number`
```csharp 
[Required]
public string Number { get; set; } = string.Empty;
```
- **Required:** The order number is mandatory.
- Represents the unique identifier for the purchase order.

### `ClientCode`
```csharp
[Required]
public string ClientCode { get; set; } = string.Empty;
```
- **Required:** The client code is mandatory.
- Represents the code assigned to a client.

### `ClientName`
```csharp
[Required]
public string ClientName { get; set; } = string.Empty;
```
- **Required:** The client name is mandatory.
- Represents the name of the client associated with the order.

### `OrderDate`
```csharp
[Required]
[Format("dd.MM.yyyy")]
public DateTime? OrderDate { get; set; }
```
- **Required:** The order date is mandatory.
- **Format:** The date should be in the format "dd.MM.yyyy".
- Represents the date when the order was made.


### `ShipmentDate`
```csharp
[Format("dd.MM.yyyy")]
public DateTime? ShipmentDate { get; set; }
```
- **Format:** The shipment date should be in the format "dd.MM.yyyy".
- Represents the expected date of order shipment.

### `Quantity`
```csharp
[Required]
public int Quantity { get; set; }
```
- **Required:** The quantity is mandatory.
- Represents the number of items in the order.

### `Confirmed`
```csharp
public bool Confirmed { get; set; }
```
Represents whether the order is confirmed or not.


### `Value`
```csharp
[Required]
public double Value { get; set; }
```
- **Required:** The value is mandatory.
- Represents the total value of the order.
