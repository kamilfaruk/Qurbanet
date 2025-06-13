using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qurbanet.Helpers;
using Qurbanet.Models.Entities;

namespace Qurbanet.Models.Configurations
{
    public class AnimalConfiguration : BaseModelConfiguration<Animal>
    {
        public new void Configure(EntityTypeBuilder<Animal> builder)
        {
            base.Configure(builder);

            builder.ToTable(Constants.Tables.Animals);

            builder.Property(a => a.NameOrTag)
                .IsRequired()
                .HasMaxLength(Constants.ValidationConstants.MaxNameLength);
            builder.Property(a => a.Species).IsRequired();
            builder.Property(a => a.Breed).IsRequired();
            builder.Property(a => a.Gender).IsRequired();
            builder.Property(a => a.WeightKg).IsRequired();
            builder.Property(a => a.Price).HasColumnType("decimal(18,2)");
            builder.Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("Available");

            builder.HasOne(a => a.Organization)
                .WithMany(o => o.Animals)
                .HasForeignKey(a => a.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
