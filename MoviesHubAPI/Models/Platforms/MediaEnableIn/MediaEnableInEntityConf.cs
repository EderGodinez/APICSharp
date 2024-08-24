using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MoviesHubAPI.Models.Platforms.EnablePlatform;

namespace MoviesHubAPI.Models.Platforms.MediaEnableIn
{
    public class MediaAvailibleInEntityConfig
    {
        public static void SetEntityConfig(EntityTypeBuilder<MediaAvailibleIn> modelBuilder)
        {
            modelBuilder.ToTable("MediaAvailibleIn");
            modelBuilder.HasKey(m => new { m.MediaId, m.PlatformId });
            modelBuilder.HasOne(m => m.Media)
                .WithMany(media => media.MediaAvailibleIns)
                .HasForeignKey(m => m.MediaId);
            modelBuilder.HasOne(m => m.Platform)
                .WithMany(platform => platform.MediaAvailibleIns)
                .HasForeignKey(m => m.PlatformId);
        }
    }

}
