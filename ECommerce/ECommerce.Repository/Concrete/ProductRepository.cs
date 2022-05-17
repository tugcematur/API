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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(Context db): base(db)
        {

        }

        public IQueryable<ProductList> GetProductList()
        {
            return Set().Select(p => new ProductList
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                CategoryName = p.Category.CategoryName,
                UnitName = p.Unit.UnitName,
                Stock = p.Stock,
                UnitPrice = p.UnitPrice
            });
        }

        public IQueryable<ProductList> GetProductListByCatId(int id)
        {
            return Set().Select(p => new ProductList
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                CategoryName = p.Category.CategoryName,
                UnitName = p.Unit.UnitName,
                Stock = p.Stock,
                UnitPrice = p.UnitPrice,
                CategoryId = p.CategoryId

            }).Where(p => p.CategoryId == id);
        }
    }
}
