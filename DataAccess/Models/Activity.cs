using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActivityId { get; set; }
        public Guid StaffId { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff? Staff { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
    }
}
