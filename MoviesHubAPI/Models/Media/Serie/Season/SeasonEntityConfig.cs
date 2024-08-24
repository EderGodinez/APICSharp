using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.MediaF.SerieF.SeasonF
{
    public class SeasonEntityConfig
    {
        public static void SetEntityConfig(EntityTypeBuilder<Season> modelBuilder)
        {

            modelBuilder.ToTable("Season");

            modelBuilder.HasKey(s => s.Id);

            modelBuilder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.HasMany(s => s.EpisodeLists)
                .WithOne(el => el.Season)
                .HasForeignKey(el => el.SeasonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
