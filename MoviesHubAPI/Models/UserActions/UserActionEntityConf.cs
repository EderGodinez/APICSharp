using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesHubAPI.Models.UserActionsF
{
    public class UserActionEntityConf
    {
        public static void setEntityConfig(EntityTypeBuilder<UserAction> builder)
        {
            builder.ToTable("UserActions");
            builder.HasKey(ua => new { ua.UserId, ua.MediaId, ua.TypeAction });
            builder.HasOne(ua => ua.Media)
                   .WithMany(m => m.UserActions)
                   .HasForeignKey(ua => ua.MediaId);
        }
    }
}
