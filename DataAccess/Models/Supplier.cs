using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string? Email { get; set; }
        [StringLength(11)]
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
