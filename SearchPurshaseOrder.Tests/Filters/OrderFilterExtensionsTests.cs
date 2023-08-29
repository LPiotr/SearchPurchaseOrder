using SearchPurchaseOrder.Filters;
using System.Globalization;

namespace SearchPurchaseOrder.Tests
{
    public class OrderFilterExtensionsTests
    {
        private readonly List<PurchaseOrder> _sampleOrders = new()
        {
            new PurchaseOrder { Number = "001", ClientCode = "CL001", OrderDate = DateTime.ParseExact("01.01.2023", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
            new PurchaseOrder { Number = "002", ClientCode = "CL002", OrderDate = DateTime.ParseExact("05.05.2023", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
            new PurchaseOrder { Number = "003", ClientCode = "CL001", OrderDate = DateTime.ParseExact("10.10.2023", "dd.MM.yyyy", CultureInfo.InvariantCulture) }
        };

        [Fact]
        public void FilterByNumber_WithOrderNumber_ShouldReturnFilteredOrders()
        {
            var filtered = _sampleOrders.FilterByNumber("001").ToList();

            Assert.Single(filtered);
            Assert.Equal("001", filtered[0].Number);
        }

        [Fact]
        public void FilterByNumber_WithoutOrderNumber_ShouldReturnAllOrders()
        {
            var filtered = _sampleOrders.FilterByNumber(null).ToList();

            Assert.Equal(3, filtered.Count);
        }

        [Fact]
        public void FilterByClientCode_WithClientCodes_ShouldReturnFilteredOrders()
        {
            var clientCodes = new List<string> { "CL001" };
            var filtered = _sampleOrders.FilterByClientCode(clientCodes).ToList();

            Assert.Equal(2, filtered.Count);
            Assert.All(filtered, o => Assert.Equal("CL001", o.ClientCode));
        }

        [Fact]
        public void FilterByClientCode_WithoutClientCodes_ShouldReturnAllOrders()
        {
            var filtered = _sampleOrders.FilterByClientCode(null).ToList();

            Assert.Equal(3, filtered.Count);
        }

        [Fact]
        public void FilterByDate_ValidDateRange_ShouldReturnFilteredOrders()
        {
            var filtered = _sampleOrders.FilterByDate("01.01.2023", "05.05.2023").ToList();

            Assert.Equal(2, filtered.Count);
        }

        [Fact]
        public void FilterByDate_ValidDateRange_ShouldReturnAllOrdersWhenNulls()
        {
            var filtered = _sampleOrders.FilterByDate(null, null).ToList();

            Assert.Equal(3, filtered.Count);
        }

        [Fact]
        public void FilterByDate_InvalidDateRange_ShouldReturnAllOrders()
        {
            var filtered = _sampleOrders.FilterByDate("invalidDate", null).ToList();

            Assert.Equal(3, filtered.Count);
        }

        [Fact]
        public void FilterByDate_NullDateRange_ShouldReturnAllOrders()
        {
            var filtered = _sampleOrders.FilterByDate(null, null).ToList();

            Assert.Equal(3, filtered.Count);
        }
    }
}
