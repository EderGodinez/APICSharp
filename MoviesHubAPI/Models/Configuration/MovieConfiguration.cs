using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)

        {
            
            builder.HasKey(m => m.MediaId);

            builder.Property(m => m.Duration)
                .IsRequired();

            builder.HasOne(m => m.Media)
                .WithOne(mv => mv.Movie)
                .HasForeignKey<Movie>(m => m.MediaId);
        }
    }
}
