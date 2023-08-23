using MediatR;
using SearchPurchaseOrder.Models;

namespace SearchPurchaseOrder.Queries
{
    public class SearchPurchaseOrdersQuery : IRequest<IEnumerable<PurchaseOrder>>
    {
        public string? Number { get; set; }
        public string StartDate { get; set; } = string.Empty;
        public string? EndDate { get; set; }
        public List<string>? ClientCodes { get; set; }
    }
}
