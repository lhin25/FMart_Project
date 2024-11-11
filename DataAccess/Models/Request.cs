using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Request
    {
        [Key]
        public Guid RequestId { get; set; }
        public int RecordType { get; set; }
        public Guid StaffId { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff? Staff { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsAccepted { get; set; } = false;
        public virtual ICollection<RequestDetail> RequestDetails { get; set; }
    }
}
