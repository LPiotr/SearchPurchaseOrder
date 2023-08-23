using SearchPurchaseOrder.Filters;

namespace SearchPurchaseOrder.Tests
{
    public class OrderFilterTests
    {
        private readonly IOrderFilter _orderFilter;

        public OrderFilterTests()
        {
            _orderFilter = new PurchaseOrderFilters();
        }

        [Fact]
        public void Filter_ShouldReturnFilteredOrdersBasedOnQuery()
        {
            // Arrange
            var orders = new List<PurchaseOrder>
            {
                new PurchaseOrder { Number = "001", ClientCode = "CL001", OrderDate = DateTime.Parse("2023-01-01") },
                new PurchaseOrder { Number = "002", ClientCode = "CL002", OrderDate = DateTime.Parse("2023-02-01") }
            };

            var query = new SearchPurchaseOrdersQuery
            {
                Number = "001",
                ClientCodes = new List<string> { "CL001", "CL002" },
                StartDate = "2023-01-01",
                EndDate = "2023-12-31"
            };

            // Act
            var filteredOrders = _orderFilter.Filter(orders, query);

            // Assert
            Assert.Single(filteredOrders);
            Assert.Equal("001", filteredOrders.First().Number);
            Assert.Equal("CL001", filteredOrders.First().ClientCode);
        }
    }
}
