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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context db) : base(db)
        {
            
        }

        public IQueryable<CategoryList> GetCategoryList()
        {
            return Set().Select(x => new CategoryList
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            });
        }
    }
}
