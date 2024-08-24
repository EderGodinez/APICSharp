using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.MediaF.SerieF.Episodes
{
    public class EpisodeEntityConfig
    {
        public static void SetEntityConfig(EntityTypeBuilder<Episode> modelBuilder)
        {
            modelBuilder.ToTable("Episode");

            modelBuilder.HasKey(e => e.Id);

            modelBuilder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            modelBuilder.Property(e => e.Title)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Property(e => e.Overview)
                .IsRequired();

            modelBuilder.Property(e => e.E_Num)
                .IsRequired();

            modelBuilder.Property(e => e.Duration)
                .IsRequired();

            modelBuilder.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Property(e => e.AddedDate)
                .HasColumnType("smalldatetime")
                .IsRequired();

            modelBuilder.Property(e => e.WatchLink)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Property(e => e.RelaseDate)
                .HasColumnType("smalldatetime")
                .IsRequired();
            modelBuilder.HasMany(e => e.EpisodeLists)
               .WithOne(el => el.Episode)
               .HasForeignKey(el => el.EpisodeId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
