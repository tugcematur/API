using Microsoft.EntityFrameworkCore;

namespace NMAPI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> op) : base(op)
        {
        }


        public DbSet<Vatandas> Vatandas { get; set; }
    }
}
