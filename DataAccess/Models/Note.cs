using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Note
    {
        [Key]
        public Guid NoteId { get; set; }
        public int RecordType { get; set; }
        public Guid StaffId { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff? Staff { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual ICollection<NoteDetail> NoteDetails { get; set; }
    }
}
