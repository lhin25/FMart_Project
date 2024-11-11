using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier? Supplier { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal ImportPrice { get; set; }
        public int StockQty { get; set; } = 0;
        public int SaleQty { get; set; } = 0;
        public string? ProductImg { get; set; }
        [StringLength(15)]
        public string Barcode { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}
