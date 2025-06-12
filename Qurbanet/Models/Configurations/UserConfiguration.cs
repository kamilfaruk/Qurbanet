using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Qurbanet.Models.Enums;
using Qurbanet.Helpers;
using Qurbanet.Models.Entities;


namespace Qurbanet.Models.Configurations
{
    public class UserConfiguration : BaseModelConfiguration<User>
    {
        public new void Configure(EntityTypeBuilder<User> builder)
        {
            // Call base configuration
            base.Configure(builder);

            builder.ToTable(Constants.Tables.Users);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(Constants.ValidationConstants.MaxUsernameLength);

            builder.Property(u => u.Surname)
                .IsRequired()
                .HasMaxLength(Constants.ValidationConstants.MaxSurnameLength);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(Constants.ValidationConstants.MaxUsernameLength);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(Constants.ValidationConstants.MaxPasswordLength);

            builder.Property(u => u.Email)
                .HasMaxLength(Constants.ValidationConstants.MaxEmailLength);

            builder.Property(u => u.Phone)
                .HasMaxLength(Constants.ValidationConstants.MaxPhoneLength);

            builder.Property(u => u.UserType)
                .IsRequired()
                .HasDefaultValue(UserType.User);
        }
    }
}
