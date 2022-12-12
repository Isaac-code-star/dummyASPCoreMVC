using dummyASPCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace dummyASPCoreMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CategoryModel> CategoryModel { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }
       
    }
}
