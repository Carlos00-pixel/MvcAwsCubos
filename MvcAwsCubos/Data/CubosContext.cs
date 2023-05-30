using Microsoft.EntityFrameworkCore;
using MvcAwsCubos.Models;

namespace MvcAwsCubos.Data
{
    public class CubosContext : DbContext
    {
        public CubosContext(DbContextOptions<CubosContext> options) : base(options)
        {
        }

        public DbSet<Cubo> Cubos { get; set; }
    }
}
