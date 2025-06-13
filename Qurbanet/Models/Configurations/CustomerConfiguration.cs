using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qurbanet.Helpers;
using Qurbanet.Models.Entities;

namespace Qurbanet.Models.Configurations
{
    public class CustomerConfiguration : BaseModelConfiguration<Customer>
    {
        public new void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.ToTable(Constants.Tables.Customers);

            builder.Property(c => c.FullName)
                .IsRequired()
                .HasMaxLength(Constants.ValidationConstants.MaxNameLength);
            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(Constants.ValidationConstants.MaxPhoneLength);
            builder.Property(c => c.Email)
                .HasMaxLength(Constants.ValidationConstants.MaxEmailLength);
        }
    }
}
