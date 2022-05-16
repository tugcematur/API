using KatmanliAPI.Core;
using KatmanliAPI.Dal;
using KatmanliAPI.Entity;
using KatmanliAPI.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliAPI.Repos.Classes
{
    public  class OgrenciRepos :  BaseRepository<Ogrenci>, IOgrenciRepos
    {
        Context _db;
        public OgrenciRepos(Context db) : base(db)
        {
            _db = db;
        }
    }
}
