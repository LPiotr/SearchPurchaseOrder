using CsvHelper.Configuration.Attributes;
using MediatR;
using SearchPurchaseOrder.Models;

namespace SearchPurchaseOrder.Queries
{
    public class SearchPurchaseOrdersQuery : IRequest<IEnumerable<PurchaseOrder>>
    {
        public string? Number { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<string>? ClientCodes { get; set; }
    }
}
