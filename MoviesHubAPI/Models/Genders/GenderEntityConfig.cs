using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.Genders
{
    public class GenderEntityConfig
    {
        public static void SetEntityConfig(EntityTypeBuilder<Gender> modelBuilder)
        {
            modelBuilder.ToTable("Genders");
            modelBuilder.HasKey(g => g.Id);
            modelBuilder.HasIndex(g => g.Name).IsUnique();
        }
    }

}
