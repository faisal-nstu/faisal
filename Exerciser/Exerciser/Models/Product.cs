using Microsoft.Practices.Prism.StoreApps;
using System.ComponentModel.DataAnnotations;

namespace Exerciser.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Supplier { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
    }
}
