using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.Configurations
{
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.ToTable("Media");
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.OriginalTitle)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Overview)
                .IsRequired();

            builder.Property(m => m.ImagePath)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(m => m.PosterImage)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(m => m.TrailerLink)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(m => m.WatchLink)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(m => m.AddedDate)
                .IsRequired();

            builder.Property(m => m.TypeMedia)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(m => m.RelaseDate)
                .IsRequired();

            builder.Property(m => m.AgeRate)
                .HasMaxLength(8);

            builder.HasOne(m => m.Movie)
                .WithOne(mv => mv.Media)
                .HasForeignKey<Movie>(mv => mv.MediaId);

            builder.HasMany(m => m.GendersLists)
                .WithOne(gl => gl.Media)
                .HasForeignKey(gl => gl.MediaId);

            builder.HasMany(m => m.MediaAvailibleIns)
                .WithOne(ma => ma.Media)
                .HasForeignKey(ma => ma.MediaId);

            builder.HasMany(m => m.Ratings)
                .WithOne(r => r.Media)
                .HasForeignKey(r => r.MediaId);

            builder.HasMany(m => m.UserActions)
                .WithOne(ua => ua.Media)
                .HasForeignKey(ua => ua.MediaId);

            builder.HasMany(m => m.Seasons)
                .WithOne(s => s.Serie)
                .HasForeignKey(s => s.SerieId);
        }
    }
}
