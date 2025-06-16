using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qurbanet.Helpers;
using Qurbanet.Models.Entities;

namespace Qurbanet.Models.Configurations
{
    public class CuttingEventConfiguration : BaseModelConfiguration<CuttingEvent>
    {
        public new void Configure(EntityTypeBuilder<CuttingEvent> builder)
        {
            base.Configure(builder);

            builder.ToTable(Constants.Tables.CuttingEvents);

            builder.Property(c => c.Stage)
                .HasConversion<string>()
                .IsRequired();
            builder.Property(c => c.OrderNumber).IsRequired();

            builder.HasOne(c => c.Animal)
                .WithMany(a => a.CuttingEvents)
                .HasForeignKey(c => c.AnimalId);
        }
    }
}
