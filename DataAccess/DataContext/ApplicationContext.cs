using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DataContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestDetail> RequestDetails { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteDetail> NoteDetails { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceDetail>()
                .HasOne(i => i.Invoice)
                .WithMany(id => id.InvoiceDetails)
                .HasForeignKey(ii => ii.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RequestDetail>()
                .HasOne(i => i.Request)
                .WithMany(rd => rd.RequestDetails)
                .HasForeignKey(ri => ri.RequestId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NoteDetail>()
                .HasOne(i => i.Note)
                .WithMany(nd => nd.NoteDetails)
                .HasForeignKey(ni => ni.NoteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(pr => pr.Products)
                .HasForeignKey(pi => pi.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Staff)
                .WithMany(s => s.Invoices)
                .HasForeignKey(id => id.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Invoices)
                .HasForeignKey(ic =>  ic.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
