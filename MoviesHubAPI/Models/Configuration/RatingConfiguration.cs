using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(r => new { r.UserId, r.MediaId });

            builder.Property(r => r.Rate)
                .IsRequired();

            builder.Property(r => r.RateDate)
                .IsRequired();

            builder.HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId);

            builder.HasOne(r => r.Media)
                .WithMany(m => m.Ratings)
                .HasForeignKey(r => r.MediaId);
        }
    }
}
