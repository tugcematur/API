using KatmanliAPI.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliAPI.Dal
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }


        public DbSet<Ogrenci> Ogrenci { get; set; }
        public DbSet<Ders> Ders { get; set; }
    }
}
