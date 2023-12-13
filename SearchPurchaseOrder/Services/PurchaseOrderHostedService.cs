using SearchPurchaseOrder.Interfaces;

namespace SearchPurchaseOrder.Services
{
    public class PurchaseOrderHostedService : IHostedService
    {
        private readonly IPurchaseOrderFileReader _fileReader;

        public PurchaseOrderHostedService(IPurchaseOrderFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public IPurchaseOrderFileReader FileReader => _fileReader;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Code to start the service
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // Code to stop the service
            return Task.CompletedTask;
        }
    }
}
