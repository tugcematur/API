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
    public class CountyRepository : BaseRepository<County>, ICountyRepository
    {
        public CountyRepository(Context db) : base(db)
        {
            
        }

        public IQueryable<CountyList> GetCountyList()
        {
            return Set().Select(x => new CountyList
            {
                CountyId = x.CountyId,
                CountyName = x.CountyName,
                CityId = x.CityId
            });
        }
    }
}
