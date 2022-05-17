using ECommerce.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> op) : base(op)
        {

        }

        //public DbSet<BasketDetail>? BasketDetails { get; set; }
        //public DbSet<BasketMain>? BasketMains { get; set; }
        public DbSet<Category> ?Categories { get; set; }
        public DbSet<City> ?Cities { get; set; }
        public DbSet<County> ?Counties { get; set; }
        public DbSet<Customer> ?Customers { get; set; }
        //public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        //public DbSet<InvoiceMain> InvoiceMains { get; set; }
        public DbSet<Product> ?Products { get; set; }
        public DbSet<Supplier> ?Suppliers { get; set; }
        public DbSet<Unit> ?Units { get; set; }
        public DbSet<User> ?Users { get; set; }
    }
}
