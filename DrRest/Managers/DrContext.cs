using DrRest.Models;
using Microsoft.EntityFrameworkCore;
namespace DrRest.Managers
{
    public class DrContext : DbContext
    {
        public DrContext(DbContextOptions<DrContext> options) : base(options) { }
        public DbSet<Music> music { get; set; }
    }
}
