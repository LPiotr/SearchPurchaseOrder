using SearchPurchaseOrder.Filters;
using System.Globalization;

namespace SearchPurchaseOrder.Tests
{
    public class PurchaseOrderFiltersTests
    {
        private readonly PurchaseOrderFilters _filter;
        private readonly List<PurchaseOrder> _sampleOrders = new()
        {
            new PurchaseOrder { Number = "001", ClientCode = "CL001", OrderDate = DateTime.ParseExact("01.01.2023", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
            new PurchaseOrder { Number = "002", ClientCode = "CL002", OrderDate = DateTime.ParseExact("05.05.2023", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
            new PurchaseOrder { Number = "003", ClientCode = "CL001", OrderDate = DateTime.ParseExact("10.10.2023", "dd.MM.yyyy", CultureInfo.InvariantCulture) }
        };

        public PurchaseOrderFiltersTests()
        {
            _filter = new PurchaseOrderFilters();
        }

        [Fact]
        public void Filter_WithOrderNumberQuery_ShouldReturnFilteredOrders()
        {
            var query = new SearchPurchaseOrdersQuery { Number = "001" };

            var filtered = _filter.Filter(_sampleOrders, query).ToList();

            Assert.Single(filtered);
            Assert.Equal("001", filtered[0].Number);
        }

        [Fact]
        public void Filter_WithClientCodeQuery_ShouldReturnFilteredOrders()
        {
            var query = new SearchPurchaseOrdersQuery { ClientCodes = new List<string> { "CL001" } };

            var filtered = _filter.Filter(_sampleOrders, query).ToList();

            Assert.Equal(2, filtered.Count);
            Assert.All(filtered, o => Assert.Equal("CL001", o.ClientCode));
        }

        [Fact]
        public void Filter_WithDateRangeQuery_ShouldReturnFilteredOrders()
        {
            var query = new SearchPurchaseOrdersQuery { StartDate = "01.01.2023", EndDate = "05.05.2023" };

            var filtered = _filter.Filter(_sampleOrders, query).ToList();

            Assert.Equal(2, filtered.Count);
        }

        [Fact]
        public void Filter_WithInvalidDateQuery_ShouldReturnAllOrders()
        {
            var query = new SearchPurchaseOrdersQuery { StartDate = "invalidDate", EndDate = "invalidDate" };

            var filtered = _filter.Filter(_sampleOrders, query).ToList();

            Assert.Equal(3, filtered.Count);
        }
    }
}
