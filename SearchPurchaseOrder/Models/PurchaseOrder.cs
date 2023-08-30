using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SearchPurchaseOrder.Models
{
    public class PurchaseOrder
    {
        [Required]
        public string Number { get; set; } = string.Empty;
        [Required]
        public string ClientCode { get; set; } = string.Empty;
        [Required]
        public string ClientName { get; set; } = string.Empty;
        [Required]
        [Format("dd.MM.yyyy")]
        public DateTime? OrderDate { get; set; }
        [Format("dd.MM.yyyy")]
        public DateTime? ShipmentDate { get; set; }
        [Required]
        public int Quantity { get; set; }
        public bool Confirmed { get; set; }
        [Required]
        public double Value { get; set; }
    }
}
