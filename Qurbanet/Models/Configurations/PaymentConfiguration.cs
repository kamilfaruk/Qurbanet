using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qurbanet.Helpers;
using Qurbanet.Models.Entities;

namespace Qurbanet.Models.Configurations
{
    public class PaymentConfiguration : BaseModelConfiguration<Payment>
    {
        public new void Configure(EntityTypeBuilder<Payment> builder)
        {
            base.Configure(builder);

            builder.ToTable(Constants.Tables.Payments);

            builder.Property(p => p.Amount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PaymentDate).IsRequired();

            builder.HasOne(p => p.Sale)
                .WithMany(s => s.Payments)
                .HasForeignKey(p => p.SaleId);
        }
    }
}
