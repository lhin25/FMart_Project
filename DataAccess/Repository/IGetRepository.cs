using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IGetRepository
    {
        public IActivityRepository ActivityRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public IInvoiceRepository InvoiceRepository { get; }
        public IInvoiceDetailRepository InvoiceDetailRepository { get; }
        public INoteDetailRepository NoteDetailRepository { get; }
        public INoteRepository NoteRepository { get; }
        public IRequestDetailRepository RequestDetailRepository { get; }
        public IRequestRepository RequestRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IStaffRepository StaffRepository { get; }
        public ISupplierRepository SupplierRepository { get; }
        public IProductRepository ProductRepository { get; }
    }
}
