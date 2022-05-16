using KatmanliAPI.Core;
using KatmanliAPI.Dal;
using KatmanliAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliAPI.Repos.Classes
{
    public class DersRepos : BaseRepository<Ders>, IDersRepos
    {
        Context _db;
        public DersRepos(Context db) : base(db)
        {
            _db = db;
        }
    }
}
