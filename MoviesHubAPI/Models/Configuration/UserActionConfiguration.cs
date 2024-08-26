using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.Configurations
{
    public class UserActionConfiguration : IEntityTypeConfiguration<UserAction>
    {
        public void Configure(EntityTypeBuilder<UserAction> builder)
        {
            builder.HasKey(ua => new { ua.UserId, ua.MediaId,ua.TypeAction });

            builder.Property(ua => ua.TypeAction)
                .IsRequired()
                .HasMaxLength(1);

            builder.Property(ua => ua.ActionDate)
                .IsRequired();

            builder.HasOne(ua => ua.User)
                .WithMany(u => u.UserActions)
                .HasForeignKey(ua => ua.UserId);

            builder.HasOne(ua => ua.Media)
                .WithMany(m => m.UserActions)
                .HasForeignKey(ua => ua.MediaId);
        }
    }
}
