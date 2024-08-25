using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.Configurations
{
    public class MediaAvailibleInConfiguration : IEntityTypeConfiguration<MediaAvailibleIn>
    {
        public void Configure(EntityTypeBuilder<MediaAvailibleIn> builder)
        {
            builder.HasKey(ma => new { ma.MediaId, ma.PlatformId });

            builder.HasOne(ma => ma.Media)
                .WithMany(m => m.MediaAvailibleIns)
                .HasForeignKey(ma => ma.MediaId);

            builder.HasOne(ma => ma.Platform)
                .WithMany(p => p.MediaAvailibleIns)
                .HasForeignKey(ma => ma.PlatformId);
        }
    }
}
