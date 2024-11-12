using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Request
    {
        [Key]
        public Guid RequestId { get; set; }
        public int RecordType { get; set; } //Goods_Receipt_Note = 1, Goods_Delivery_Note = 2, Goods_Return_Note = 3, Goods_Disposal_Note = 4, Inventory_Stocktaking_Note = 5
        public Guid StaffId { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff? Staff { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsAccepted { get; set; } = false;
        public virtual ICollection<RequestDetail> RequestDetails { get; set; }
    }
}
