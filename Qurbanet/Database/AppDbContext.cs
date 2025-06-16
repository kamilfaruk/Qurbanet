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
            modelBuilder.ApplyConfiguration(new BaseModelConfiguration<Organization>());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new BaseModelConfiguration<Animal>());
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new BaseModelConfiguration<Customer>());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new BaseModelConfiguration<Sale>());
            modelBuilder.ApplyConfiguration(new SaleConfiguration());
            modelBuilder.ApplyConfiguration(new BaseModelConfiguration<Payment>());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new BaseModelConfiguration<CuttingEvent>());
            modelBuilder.ApplyConfiguration(new CuttingEventConfiguration());
            modelBuilder.ApplyConfiguration(new BaseModelConfiguration<SystemLog>());
            modelBuilder.ApplyConfiguration(new SystemLogConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CuttingEvent> CuttingEvents { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }
    }
}
