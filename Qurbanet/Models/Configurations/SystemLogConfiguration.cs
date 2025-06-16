using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qurbanet.Helpers;
using Qurbanet.Models.Entities;

namespace Qurbanet.Models.Configurations
{
    public class SystemLogConfiguration : BaseModelConfiguration<SystemLog>
    {
        public new void Configure(EntityTypeBuilder<SystemLog> builder)
        {
            base.Configure(builder);

            builder.ToTable(Constants.Tables.SystemLogs);

            builder.Property(l => l.EntityType).IsRequired();
            builder.Property(l => l.Action).IsRequired();
            builder.Property(l => l.Description).IsRequired();

            builder.HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
