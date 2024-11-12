using DataAccess.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GetRepository : IGetRepository
    {
        private readonly ApplicationContext _context = new();
        private IActivityRepository? activityRepository;
        private ICategoryRepository? categoryRepository;
        private ICustomerRepository? customerRepository;
        private IInvoiceDetailRepository? invoiceDetailRepository;
        private IInvoiceRepository? invoiceRepository;
        private INoteDetailRepository? noteDetailRepository;
        private INoteRepository? noteRepository;
        private IRequestDetailRepository? requestDetailRepository;
        private IRequestRepository? requestRepository;
        private IRoleRepository? roleRepository;
        private IStaffRepository? staffRepository;
        private ISupplierRepository? supplierRepository;
        private IProductRepository? productRepository;

        public IActivityRepository ActivityRepository => activityRepository ??= new ActivityRepository(_context);

        public ICategoryRepository CategoryRepository => categoryRepository ??= new CategoryRepository(_context);

        public ICustomerRepository CustomerRepository => customerRepository ??= new CustomerRepository(_context);

        public IInvoiceRepository InvoiceRepository => invoiceRepository ??= new InvoiceRepository(_context);

        public IInvoiceDetailRepository InvoiceDetailRepository => invoiceDetailRepository ??= new InvoiceDetailRepository(_context);

        public INoteDetailRepository NoteDetailRepository => noteDetailRepository ??= new NoteDetailRepository(_context);

        public INoteRepository NoteRepository => noteRepository ??= new NoteRepository(_context);

        public IRequestDetailRepository RequestDetailRepository => requestDetailRepository ??= new RequestDetailRepository(_context);

        public IRequestRepository RequestRepository => requestRepository ??= new RequestRepository(_context);

        public IRoleRepository RoleRepository => roleRepository ??= new RoleRepository(_context);

        public IStaffRepository StaffRepository => staffRepository ??= new StaffRepository(_context);

        public ISupplierRepository SupplierRepository => supplierRepository ??= new SupplierRepository(_context);

        public IProductRepository ProductRepository => productRepository ??= new ProductRepository(_context);
    }
}
