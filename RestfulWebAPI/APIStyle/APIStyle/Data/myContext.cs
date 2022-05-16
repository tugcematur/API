using Microsoft.EntityFrameworkCore;

namespace APIStyle.Data
{
    public class myContext :  DbContext
    {
        public myContext(DbContextOptions<myContext> options)
           : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } 
        public virtual DbSet<Personel> Personels { get; set; } 
    }
}
