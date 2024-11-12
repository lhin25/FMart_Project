using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int Points { get; set; } = 0;
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
