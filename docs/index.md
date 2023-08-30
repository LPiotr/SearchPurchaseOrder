# SearchPurchaseOrder REST API Documentation

A REST API developed in NET 6 designed to search for orders stored in a CSV file based on the given filter data.

## Overview

1. File location is saved in the [configuration file](#appsettings).
2. [CSV File Description](#csv-description).
3. [Possible API Conditions](#api-conditions).
4. Ability to pass any number of conditions.
5. Implementation of the Dependency Injection and Mediator design patterns.
6. Response format: JSON.
7. Code testability.

## Project Structure

- **Configuration**
  - [PurchaseOrderDataSettings.cs](#PurchaseOrderDataSettings).
  - [PurchaseOrderMap.cs](#PurchaseOrderMap).
- **Controllers**
  - [OrdersController.cs](#OrdersController).
- **Filters**
  - [IOrderFilter.cs](#IOrderFilter).
  - [OrderFilterExtensions.cs](#OrderFilterExtensions).
  - [PurchaseOrderFilters.cs](#PurchaseOrderFilters).
- **Models**
  - [PurchaseOrder.cs](#PurchaseOrder).
- **Properties**
  - [launchSettings.json](#launchSettings).
- **Queries**
  - [SearchOrdersQueryHandler.cs](Queries/SearchOrdersQueryHandler.md).
  - [SearchPurchaseOrdersQuery.cs](Queries/SearchPurchaseOrdersQuery.md).
- **Services**
  - [CsvOrderFileReader.cs](Services/CsvOrderFileReader.md).
  - [IPurchaseOrderFileReader.cs](Services/IPurchaseOrderFileReader.md).
- **[appsettings.Development.json](#appsettings-development)**.
- **[appsettings.json](#appsettings)**.
- **[data.csv](#data-csv)**.
- **[Program.cs](#Program)**.

### <a name="csv-description"></a>CSV File Description

#### File Structure:
- The first line of the CSV file are headers.
- Column separator: comma.
- Decimal point for real numbers: dot.
- Date format: dd.MM.yyyy.
- Representation for true/false values: 1/0.
- Text data in quotes.
- Encoding: UTF-8.

#### Columns
| Header | Data Type | Required |
| ------ | --------- | -------- |
| Number | Text      | Yes      |
| ClientCode | Text  | Yes      |
| ClientName | Text  | Yes      |
| OrderDate  | Date  | Yes      |
| ShipmentDate| Date | No       |
| Quantity  | Integer | Yes     |
| Confirmed | Boolean | Yes     |
| Value     | Float   | Yes     |

### <a name="api-conditions"></a>Possible API Conditions
- Order number.
- Order date in the form of a range from-to.
- Client code in the form of a list.