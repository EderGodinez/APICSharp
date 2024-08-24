using Microsoft.EntityFrameworkCore;
using MoviesHubAPI.Models.Genders;
using MoviesHubAPI.Models.Genders.GenderListF;
using MoviesHubAPI.Models.MediaF;
using MoviesHubAPI.Models.MediaF.MovieF;
using MoviesHubAPI.Models.MediaF.SerieF;
using MoviesHubAPI.Models.MediaF.SerieF.EpisodeListF;
using MoviesHubAPI.Models.MediaF.SerieF.Episodes;
using MoviesHubAPI.Models.MediaF.SerieF.SeasonF;
using MoviesHubAPI.Models.Platforms;
using MoviesHubAPI.Models.Platforms.EnablePlatform;
using MoviesHubAPI.Models.Platforms.MediaEnableIn;
using MoviesHubAPI.Models.Ratings;
using MoviesHubAPI.Models.UserF;
using MoviesHubAPI.Models.UserActionsF;

namespace EntityFrameworkExample.Context
{
    public class ContextDB : DbContext, IContextDB
    {
        public ContextDB(DbContextOptions<ContextDB> options)
        : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserEntityConfig.setEntityConfig(modelBuilder.Entity<User>());
            UserActionEntityConf.setEntityConfig(modelBuilder.Entity<UserAction>());
            RatingEntityConfig.SetEntityConfig(modelBuilder.Entity<Rating>());
            MovieEntityConfig.SetEntityConfig(modelBuilder.Entity<Movie>());
            MediaEntityConfig.SetEntityConfig(modelBuilder.Entity<Media>());
            PlatformEntityConfig.SetEntityConfig(modelBuilder.Entity<Platform>());
            MediaAvailibleInEntityConfig.SetEntityConfig(modelBuilder.Entity<MediaAvailibleIn>());
            GenderEntityConfig.SetEntityConfig(modelBuilder.Entity<Gender>());
            GenderListEntityConfig.SetEntityConfig(modelBuilder.Entity<GenderList>());
            SeasonEntityConfig.SetEntityConfig(modelBuilder.Entity<Season>());
            EpisodeListEntityConfig.SetEntityConfig(modelBuilder.Entity<EpisodeList>());
            EpisodeEntityConfig.SetEntityConfig(modelBuilder.Entity<Episode>());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Serie> Series { get; set; }
    }
}
