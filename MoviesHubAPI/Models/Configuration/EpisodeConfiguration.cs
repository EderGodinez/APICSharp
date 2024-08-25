using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.Configurations
{
    public class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
    {
        public void Configure(EntityTypeBuilder<Episode> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Overview)
                .IsRequired();

            builder.Property(e => e.E_Num)
                .IsRequired();

            builder.Property(e => e.Duration)
                .IsRequired();

            builder.Property(e => e.ImagePath)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.AddedDate)
                .IsRequired();

            builder.Property(e => e.WatchLink)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.RelaseDate)
                .IsRequired();

            builder.HasMany(e => e.EpisodesLists)
                .WithOne(el => el.Episode)
                .HasForeignKey(el => el.Episodeld);
        }
    }
}
