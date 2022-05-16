using KatmanliAPI.Dal;
using KatmanliAPI.Repos;
using KatmanliAPI.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliAPI.Uow
{
    public class UOFW : IUOFW
    {
        Context _db;
        public UOFW(Context db,IOgrenciRepos ogrRepos, IDersRepos dersRepos)
        {
            _db = db;
            _ogrRepos = ogrRepos;
            _dersRepos = dersRepos;
            
        }

        public IDersRepos _dersRepos {get;set;}

        public IOgrenciRepos _ogrRepos { get; set; }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
