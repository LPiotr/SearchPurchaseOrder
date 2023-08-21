namespace SearchPurchaseOrder.Tests
{
    public class PurchaseOrdersControllerTests
    {
        [Fact]
        public async Task GetOrders_SendsQueryToMediator_ReturnsOkResultWithOrders()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var dateParserMock = new Mock<IDateParser>();
            var parameters = new SearchPurchaseOrdersQuery
            {
                Number = "001",
                StartDate = new DateTime(2022, 1, 1),
                EndDate = new DateTime(2022, 12, 31),
                ClientCodes = new List<string> { "CL001", "CL002" }
            };

            var expectedResult = new List<PurchaseOrder>
            {
                new PurchaseOrder { Number = "001", ClientCode = "CL001" },
            };

            mediatorMock.Setup(m => m.Send(It.IsAny<SearchPurchaseOrdersQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            dateParserMock.Setup(d => d.ParseDateToDesiredFormat(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string date, string format) => DateTime.ParseExact(date, format, null));

            var controller = new PurchaseOrdersController(mediatorMock.Object, dateParserMock.Object);

            var result = await controller.GetOrders(parameters);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedOrders = Assert.IsAssignableFrom<IEnumerable<PurchaseOrder>>(okResult.Value);
            Assert.Equal(expectedResult, returnedOrders);
        }
    }
}