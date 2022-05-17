using ECommerce.Core;
using ECommerce.DAL;
using ECommerce.Entity;
using ECommerce.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Concrete
{
    public class BasketMainRepository: BaseRepository<BasketMain>, IBasketMainRepository
    {
        public BasketMainRepository(Context db): base(db)
        {
            
        }
    }
}
