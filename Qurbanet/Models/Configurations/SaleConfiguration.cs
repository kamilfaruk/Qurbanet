using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qurbanet.Helpers;
using Qurbanet.Models.Entities;

namespace Qurbanet.Models.Configurations
{
    public class SaleConfiguration : BaseModelConfiguration<Sale>
    {
        public new void Configure(EntityTypeBuilder<Sale> builder)
        {
            base.Configure(builder);

            builder.ToTable(Constants.Tables.Sales);

            builder.Property(s => s.SalePrice).HasColumnType("decimal(18,2)");
            builder.Property(s => s.AmountPaid).HasColumnType("decimal(18,2)");
            builder.Property(s => s.SaleDate).IsRequired();

            builder.HasOne(s => s.Animal)
                .WithOne(a => a.Sale)
                .HasForeignKey<Sale>(s => s.AnimalId);
            builder.HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId);
        }
    }
}
