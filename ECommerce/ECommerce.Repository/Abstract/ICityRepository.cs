﻿using ECommerce.Core;
using ECommerce.DTO;
using ECommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Abstract
{
    public interface ICityRepository : IBaseRepository<City>
    {
        IQueryable<CityList> GetCityList();
    }
}
