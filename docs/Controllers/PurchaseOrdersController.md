# `PurchaseOrdersController` Class Documentation

## Overview

The PurchaseOrdersController class is responsible for handling HTTP requests related to purchase orders. The class utilizes the MediatR library to send queries and handle command messages.

## Namespace

```csharp
namespace SearchPurchaseOrder.Controllers
```
This class is part of the SearchPurchaseOrder.Controllers namespace.

## Dependencies
- **MediatR:** Used for sending commands and queries within the application architecture.
- **Microsoft.AspNetCore.Mvc:** Provides attributes and base classes for building web APIs.

## Attributes
- **ApiController:** Indicates that the class is an API controller with API-specific behaviors.
- **Route:** Defines the route for the API controller as `[controller]`. This means requests will be mapped to the controller based on its name.

## Class Properties and Fields
### **`_mediator`**
```csharp 
private readonly IMediator _mediator;
```
Represents a mediator object, which is used to send commands or queries.

## Constructor
### **`PurchaseOrdersController`**
```csharp
public PurchaseOrdersController(IMediator mediator)
```
The constructor takes an IMediator instance as a parameter and initializes the _mediator field.

## API Endpoints

### **`GetOrders`**
```csharp
[HttpGet]
public async Task<IActionResult> GetOrders([FromQuery] SearchPurchaseOrdersQuery parameters)
```
- **HTTP Method:** GET
- **Route: `PurchaseOrders`** (inferred from the controller name and the HTTP method)
- Parameters: Accepts query parameters defined by the **`SearchPurchaseOrdersQuery`** class.
- Description: This endpoint retrieves purchase orders based on the provided query parameters. It constructs a new **`SearchPurchaseOrdersQuery`** instance from the provided parameters and uses the mediator to send this query. The result is then returned as a successful HTTP response.