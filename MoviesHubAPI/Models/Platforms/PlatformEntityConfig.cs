using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.Platforms
{
    public class PlatformEntityConfig
    {
        public static void SetEntityConfig(EntityTypeBuilder<Platform> modelBuilder)
        {
            modelBuilder.ToTable("Platforms");

            modelBuilder.HasKey(p => p.Id);

            modelBuilder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.HasIndex(p => p.Name)
                .IsUnique()
                .HasDatabaseName("IX_Platforms_Name");
        }
    }

}
