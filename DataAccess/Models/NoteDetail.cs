using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class NoteDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteDetailId { get; set; }
        public Guid NoteId { get; set; }
        [ForeignKey("NoteId")]
        public virtual Note? Note { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }
        public int? Quantity { get; set; }
        public int? RealQuantity { get; set; }
        public int? ExpectedQuantity { get; set; }
    }
}
