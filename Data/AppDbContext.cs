using Microsoft.EntityFrameworkCore;
using testapiproject.Models;

namespace testapiproject.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<Category> Categories { get; set; }
    }
}
