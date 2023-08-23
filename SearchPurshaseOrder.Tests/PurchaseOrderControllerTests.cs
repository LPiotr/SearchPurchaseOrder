namespace SearchPurchaseOrder.Tests
{
    public class PurchaseOrdersControllerTests
    {
        [Fact]
        public async Task GetOrders_SendsQueryToMediator_ReturnsOkResultWithOrders()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var parameters = new SearchPurchaseOrdersQuery
            {
                Number = "001",
                StartDate = "01.01.2023",  
                EndDate = "03.01.2023",    
                ClientCodes = new List<string> { "CL001", "CL002" }
            };

            var expectedResult = new List<PurchaseOrder>
            {
                new PurchaseOrder { Number = "001", ClientCode = "CL001" },
            };

            mediatorMock.Setup(m => m.Send(It.IsAny<SearchPurchaseOrdersQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var controller = new PurchaseOrdersController(mediatorMock.Object);

            // Act
            var result = await controller.GetOrders(parameters);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedOrders = Assert.IsAssignableFrom<IEnumerable<PurchaseOrder>>(okResult.Value);
            Assert.Equal(expectedResult, returnedOrders);
        }
    }
}
