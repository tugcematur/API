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
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(Context db) : base(db)
        {

        }

        public IQueryable<CityList> GetCityList()
        {
            return Set().Select(x => new CityList
            {
                CityId = x.CityId,
                CityName = x.CityName
            });
        }
    }
}
