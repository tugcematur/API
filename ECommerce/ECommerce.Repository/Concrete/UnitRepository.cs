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
    public class UnitRepository : BaseRepository<Unit>, IUnitRepository
    {
        public UnitRepository(Context db) : base(db)
        {
            
        }

        public IQueryable<UnitList> GetUnitList()
        {
            return Set().Select(x => new UnitList
            {
                UnitId = x.UnitId,
                UnitName = x.UnitName
            });
        }
    }
}
