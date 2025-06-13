using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Qurbanet.Models.Entities;

namespace Qurbanet.Models.Configurations
{
    public class BaseModelConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseModel
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            // Primary key
            builder.HasKey(b => b.Id);

            // Common properties
            builder.Property(b => b.CreateDate)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(b => b.UpdateDate)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(b => b.CreateUserId)
                .IsRequired();

            builder.Property(b => b.UpdateUserId)
                .IsRequired();

            builder.Property(b => b.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
