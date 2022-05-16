using KatmanliAPI.Repos;
using KatmanliAPI.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliAPI.Uow
{
    public  interface IUOFW
    {
        IDersRepos _dersRepos { get; }
        IOgrenciRepos _ogrRepos { get; }

        void Commit();
        void Dispose();
    }
}
