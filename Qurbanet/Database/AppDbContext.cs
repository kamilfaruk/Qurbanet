using Microsoft.EntityFrameworkCore;
using Qurbanet.Models.Configurations;
using Qurbanet.Models.Entities;

namespace Qurbanet.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BaseModelConfiguration<User>());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<User> Users { get; set; }
    }
}
