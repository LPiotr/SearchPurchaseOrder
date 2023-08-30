# `SearchOrdersQueryHandler` Class Documentation

## Class Structure
The `SearchOrdersQueryHandler` class inherits from `IRequestHandler<SearchPurchaseOrdersQuery, IEnumerable<PurchaseOrder>>`. The class has the following private fields:

- `_reader` of type `IPurchaseOrderFileReader`: Utilized for reading purchase orders from files.
- `_filter` of type `IOrderFilter`: Provides functionality for filtering orders based on conditions.
- `_filePath` of type `string`: Holds the path to the file where purchase orders are stored.

## Constructor
The class features a constructor accepting three parameters:

```csharp
public SearchOrdersQueryHandler(
    IPurchaseOrderFileReader reader,
    IOrderFilter filter,
    IOptions<PurchaseOrderDataSettings> settings
)
```

This constructor initializes the fields _reader, _filter, and _filePath using the provided arguments.

## Methods
'Handle' 
The Handle method is designed to asynchronously manage the incoming SearchPurchaseOrdersQuery requests.
```csharp
public async Task<IEnumerable<PurchaseOrder>> Handle(
    SearchPurchaseOrdersQuery request,
    CancellationToken cancellationToken
)
```

The method carries out the following operations in sequence:
1. Reads all orders from the indicated file path.
2. Filters them based on the criteria specified in the request.
3. Returns the orders post-filtering.