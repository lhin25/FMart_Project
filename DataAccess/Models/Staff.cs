using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Staff
    {
        [Key]
        public Guid StaffId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role? Role { get; set; }
        [StringLength(11)]
        public string? PhoneNumber { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
