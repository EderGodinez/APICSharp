using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.Genders.GenderListF
{
    public class GenderListEntityConfig
    {
        public static void SetEntityConfig(EntityTypeBuilder<GenderList> modelBuilder)
        {
            modelBuilder.ToTable("GendersList");
            modelBuilder.HasKey(gl => new { gl.MediaId, gl.GenderId });
            modelBuilder.HasOne(gl => gl.Media)
                   .WithMany(m => m.GenderLists)
                   .HasForeignKey(gl => gl.MediaId);
            modelBuilder.HasOne(gl => gl.Gender)
                   .WithMany(g => g.GenderLists)
                   .HasForeignKey(gl => gl.GenderId);
        }
    }
}
