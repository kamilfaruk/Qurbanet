using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qurbanet.Helpers;
using Qurbanet.Models.Entities;

namespace Qurbanet.Models.Configurations
{
    public class OrganizationConfiguration : BaseModelConfiguration<Organization>
    {
        public new void Configure(EntityTypeBuilder<Organization> builder)
        {
            base.Configure(builder);

            builder.ToTable(Constants.Tables.Organizations);

            builder.Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(Constants.ValidationConstants.MaxNameLength);

            builder.Property(o => o.Year).IsRequired();
            builder.Property(o => o.IsPaid).HasDefaultValue(false);
            builder.Property(o => o.StartDate).IsRequired();
            builder.Property(o => o.EndDate).IsRequired();

            builder.HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
