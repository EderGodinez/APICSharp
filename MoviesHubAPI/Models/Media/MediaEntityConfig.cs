using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.MediaF
{
    public class MediaEntityConfig
    {
        public static void SetEntityConfig(EntityTypeBuilder<Media> modelBuilder)
        {
            modelBuilder.ToTable("Media");
            modelBuilder.HasKey(m => m.Id);

            modelBuilder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Property(m => m.OriginalTitle)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);  

            modelBuilder.Property(m => m.Overview)
                .IsRequired()
                .HasColumnType("varchar(max)");

            modelBuilder.Property(m => m.ImagePath)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Property(m => m.PosterImage)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Property(m => m.TrailerLink)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Property(m => m.WatchLink)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Property(m => m.AddedDate)
                .IsRequired()
                .HasColumnType("smalldatetime");

            modelBuilder.Property(m => m.TypeMedia)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Property(m => m.RelaseDate)
                .IsRequired()
                .HasColumnType("smalldatetime");

            modelBuilder.Property(m => m.AgeRate)
                .HasMaxLength(8);

            modelBuilder.Property(m => m.IsActive).IsRequired();
        }
    }

}
