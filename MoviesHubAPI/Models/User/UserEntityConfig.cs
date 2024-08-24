using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.UserF
{
    public class UserEntityConfig
    {
        public static void setEntityConfig(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.ToTable(T => T.HasCheckConstraint("CK_User_Role", "[Role] IN ('admin', 'user')"));
            modelBuilder.ToTable("Users");
            modelBuilder.HasKey(u => u.Id);
            modelBuilder.Property(u => u.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            modelBuilder.Property(u => u.Password).IsRequired().HasMaxLength(150);
            modelBuilder.Property(u => u.Role).HasMaxLength(10).HasDefaultValue("user");
            modelBuilder.HasIndex(u => u.Email).IsUnique().HasDatabaseName("IX_Users_Email");
            //Relacion con tabla userActions
            modelBuilder.HasMany(u => u.UserActions)
            .WithOne(ua => ua.User)
            .HasForeignKey(ua => ua.UserId)
            .OnDelete(DeleteBehavior.Cascade);
           //Relacion con Ratings
            modelBuilder.HasMany(u => u.Ratings)
                .WithOne(r => r.user)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
