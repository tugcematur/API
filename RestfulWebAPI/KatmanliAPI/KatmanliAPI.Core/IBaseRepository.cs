﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliAPI.Core
{
    public interface IBaseRepository <T> where T : class 
    {
        DbSet<T> Set();
        T Find(int id);
        List<T> List();
        IQueryable<T> Query();

        bool Create(T ent);
        bool Delete(T ent);
        bool Update(T ent);

        void Save();

    }
}
