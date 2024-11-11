using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Invoice
    {
        [Key]
        public Guid InvoiceId { get; set; }
        public Guid StaffId { get; set; }
        [ForeignKey("StaffId")]
        public Staff? Staff { get; set; }
        public Guid? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? AppliedPoint { get; set; } = 0;
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
