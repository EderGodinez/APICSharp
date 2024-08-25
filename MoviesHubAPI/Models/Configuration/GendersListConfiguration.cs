using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.Configurations
{
    public class GendersListConfiguration : IEntityTypeConfiguration<GenderList>
    {
        public void Configure(EntityTypeBuilder<GenderList> builder)
        {
            builder.HasKey(gl => new { gl.MediaId, gl.GenderId });

            builder.HasOne(gl => gl.Media)
                .WithMany(m => m.GendersLists)
                .HasForeignKey(gl => gl.MediaId);

            builder.HasOne(gl => gl.Gender)
                .WithMany(g => g.GendersLists)
                .HasForeignKey(gl => gl.GenderId);
        }
    }
}
