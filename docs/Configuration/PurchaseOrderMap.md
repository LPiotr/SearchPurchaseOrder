# `PurchaseOrderMap` Class Documentation

## Overview

The **`PurchaseOrderMap`** class serves as a mapping configuration for the PurchaseOrder model to ensure its correct representation when working with CSV data, utilizing the CsvHelper library.
## Namespace

```csharp
SearchPurchaseOrder.Configuration
```
This class belongs to the SearchPurchaseOrder.Configuration namespace.

## Inheritance

The class inherits from ClassMap<PurchaseOrder> which is part of the CsvHelper library, ensuring each property of PurchaseOrder is mapped correctly to a corresponding CSV column.

## Constructor

### **'PurchaseOrderMap()'**
This constructor initializes the mapping configuration for the PurchaseOrder model.

- **Mappings**
  - `Number` : Maps to the CSV column named "Number".
  - `ClientCode`: Maps to the CSV column named "ClientCode".
  - `ClientName`: Maps to the CSV column named "ClientName".
  - `OrderDate`: Maps to the CSV column named "OrderDate" and uses a specific format ("dd.MM.yyyy").
  - `ShipmentDate`: Maps to the CSV column named "ShipmentDate" and uses a specific format ("dd.MM.yyyy").
  - `Quantity`: Maps to the CSV column named "Quantity".
  - `Confirmed`: Maps to the CSV column named "Confirmed".
  - `Value`: Maps to the CSV column named "Value".