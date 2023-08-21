using SearchPurchaseOrder.Models;

namespace SearchPurchaseOrder.Interfaces
{
    public interface IPurchaseOrderFileReader
    {
        Task<IEnumerable<PurchaseOrder>> ReadOrders(string path);
    }
}