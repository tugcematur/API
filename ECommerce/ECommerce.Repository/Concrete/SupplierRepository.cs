using ECommerce.Core;
using ECommerce.DAL;
using ECommerce.DTO;
using ECommerce.Entity;
using ECommerce.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Concrete
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(Context db) : base(db)
        {

        }

        public IQueryable<SupplierList> GetSupplierList()
        {
            return Set().Select(x => new SupplierList
            {
                SupplierId = x.SupplierId,
                SupplierName = x.SupplierName,
                ProductName = x.Products.Select(y => new Product
                {
                    ProductName = y.ProductName
                }).ToList()
            });
        }
    }
}
