using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.Configurations
{
    public class SeasonConfiguration : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder.HasKey(s => s.Seasonld);

            builder.Property(s => s.NumSeason)
                .IsRequired();

            builder.Property(s => s.DateRelease)
                .IsRequired();

            builder.HasOne(s => s.Serie)
                .WithMany(m => m.Seasons)
                .HasForeignKey(s => s.SerieId);

            builder.HasMany(s => s.EpisodesLists)
                .WithOne(el => el.Season)
                .HasForeignKey(el => el.Seasonld);
        }
    }
}
