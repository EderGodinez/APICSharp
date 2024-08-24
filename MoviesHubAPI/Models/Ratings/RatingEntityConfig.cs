using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesHubAPI.Models.Platforms.EnablePlatform;

namespace MoviesHubAPI.Models.Ratings
{
    public class RatingEntityConfig
    {
        public static void SetEntityConfig(EntityTypeBuilder<Rating> modelBuilder)
        {
            modelBuilder.ToTable("Ratings");
            modelBuilder.HasKey(r => new { r.UserId, r.MediaId });
            modelBuilder.HasOne(r => r.Media)
                   .WithMany(m => m.Ratings)
                   .HasForeignKey(r => r.MediaId);



        }
    }
}
