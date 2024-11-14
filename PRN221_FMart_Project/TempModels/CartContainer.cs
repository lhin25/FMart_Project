using DataAccess.Models;

namespace PRN221_FMart_Project.TempModels
{
    public class CartContainer
    {
        public List<ItemDetail> Items { get; set; }
        public Guid? CustomerId { get; set; }
        public decimal Total { get; set; }
    }
}
