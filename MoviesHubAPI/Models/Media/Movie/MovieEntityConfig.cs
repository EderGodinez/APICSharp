using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.MediaF.MovieF
{
    public class MovieEntityConfig
    {

        public static void SetEntityConfig(EntityTypeBuilder<Movie> modelBuilder)
        {
            modelBuilder.ToTable("Movie");

            modelBuilder.Property(m => m.Duration)
                        .IsRequired()
                        .HasColumnType("time(7)");
        }
    }
}