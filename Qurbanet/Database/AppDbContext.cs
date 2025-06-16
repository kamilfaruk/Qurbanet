using Microsoft.EntityFrameworkCore;
using Qurbanet.Models.Configurations;
using Qurbanet.Models.Entities;
using Qurbanet.Services.Common;
using System.Threading;

namespace Qurbanet.Database
{
    public class AppDbContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
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

        private void ApplyAuditInfo()
        {
            var entries = ChangeTracker.Entries<BaseModel>();
            var userId = _currentUserService.UserId ?? 0;
            var now = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreateDate = now;
                    entry.Entity.UpdateDate = now;
                    entry.Entity.CreateUserId = userId;
                    entry.Entity.UpdateUserId = userId;
                    entry.Entity.IsDeleted = false;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdateDate = now;
                    entry.Entity.UpdateUserId = userId;
                    entry.Property(e => e.CreateDate).IsModified = false;
                    entry.Property(e => e.CreateUserId).IsModified = false;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.UpdateDate = now;
                    entry.Entity.UpdateUserId = userId;
                    entry.Property(e => e.CreateDate).IsModified = false;
                    entry.Property(e => e.CreateUserId).IsModified = false;
                }
            }
        }

        public override int SaveChanges()
        {
            ApplyAuditInfo();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
