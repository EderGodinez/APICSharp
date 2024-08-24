using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.MediaF.SerieF.EpisodeListF
{
    public class EpisodeListEntityConfig
    {
        public static void SetEntityConfig(EntityTypeBuilder<EpisodeList> modelBuilder)
        {
            modelBuilder.ToTable("EpisodeList");

            modelBuilder.HasKey(el => new { el.SeasonId, el.EpisodeId });

            modelBuilder.HasOne(el => el.Season)
                .WithMany(s => s.EpisodeLists)
                .HasForeignKey(el => el.SeasonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.HasOne(el => el.Episode)
                .WithMany(e => e.EpisodeLists)
                .HasForeignKey(el => el.EpisodeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
