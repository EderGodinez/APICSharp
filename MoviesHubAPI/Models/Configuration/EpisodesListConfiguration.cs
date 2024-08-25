using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.Configurations
{
    public class EpisodesListConfiguration : IEntityTypeConfiguration<EpisodeList>
    {
        public void Configure(EntityTypeBuilder<EpisodeList> builder)
        {
            builder.HasKey(el => new { el.Seasonld, el.Episodeld });

            builder.HasOne(el => el.Season)
                .WithMany(s => s.EpisodesLists)
                .HasForeignKey(el => el.Seasonld);

            builder.HasOne(el => el.Episode)
                .WithMany(e => e.EpisodesLists)
                .HasForeignKey(el => el.Episodeld);
        }
    }
}
